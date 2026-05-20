using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataManagement.Common;
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Mappers;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Services
{
    public class PagoDataService : IPagoDataService
    {
        private readonly AlquilerDbContext _context;

        public PagoDataService(AlquilerDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<PagoDataModel>> GetPagedAsync(PagoFiltroDataModel filtro)
        {
            var query = _context.Pagos.AsQueryable();

            if (filtro.ReservaIdFiltro.HasValue)
                query = query.Where(x => x.RES_id == filtro.ReservaIdFiltro.Value);

            if (!string.IsNullOrEmpty(filtro.MetodoFiltro))
                query = query.Where(x => x.PAG_metodo == filtro.MetodoFiltro);

            if (!string.IsNullOrEmpty(filtro.EstadoFiltro))
                query = query.Where(x => x.PAG_estado == filtro.EstadoFiltro);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<PagoDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<PagoDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Pagos.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<PagoDataModel> AddAsync(PagoDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Pagos.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<PagoDataModel> UpdateAsync(PagoDataModel model)
        {
            var entity = model.ToEntity();
            _context.Pagos.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Pagos.FindAsync(id);
            if (entity == null) return false;

            _context.Pagos.Remove(entity);
            return true;
        }
    }
}