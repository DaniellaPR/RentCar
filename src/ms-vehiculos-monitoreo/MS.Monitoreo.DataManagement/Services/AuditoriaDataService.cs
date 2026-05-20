using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Monitoreo.DataAccess.Context;
using MS.Monitoreo.DataAccess.Entities;
using MS.Monitoreo.DataManagement.Common;
using MS.Monitoreo.DataManagement.Interfaces;
using MS.Monitoreo.DataManagement.Mappers; // <-- Esta línea es vital para que reconozca el ToDataModel
using MS.Monitoreo.DataManagement.Models;

namespace MS.Monitoreo.DataManagement.Services
{
    public class AuditoriaDataService : IAuditoriaDataService
    {
        private readonly MonitoreoDbContext _context;

        public AuditoriaDataService(MonitoreoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<AuditoriaDataModel>> GetPagedAsync(AuditoriaFiltroDataModel filtro)
        {
            var query = _context.Auditorias.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.NombreTablaFiltro))
                query = query.Where(x => x.AUD_nombreTabla.Contains(filtro.NombreTablaFiltro));

            if (!string.IsNullOrEmpty(filtro.OperacionFiltro))
                query = query.Where(x => x.AUD_operacion == filtro.OperacionFiltro);

            query = query.OrderByDescending(x => x.AUD_fecha);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<AuditoriaDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<AuditoriaDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Auditorias.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<AuditoriaDataModel> AddAsync(AuditoriaDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Auditorias.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<AuditoriaDataModel> UpdateAsync(AuditoriaDataModel model)
        {
            var entity = model.ToEntity();
            _context.Auditorias.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Auditorias.FindAsync(id);
            if (entity == null) return false;

            _context.Auditorias.Remove(entity);
            return true;
        }
    }
}