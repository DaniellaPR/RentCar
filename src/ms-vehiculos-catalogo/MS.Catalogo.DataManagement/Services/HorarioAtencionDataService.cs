using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Mappers;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Services
{
    public class HorarioAtencionDataService : IHorarioAtencionDataService
    {
        private readonly CatalogoDbContext _context;

        public HorarioAtencionDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<HorarioAtencionDataModel>> GetPagedAsync(HorarioAtencionFiltroDataModel filtro)
        {
            var query = _context.HorariosAtencion.AsQueryable();

            if (filtro.SucursalIdFiltro.HasValue)
                query = query.Where(x => x.SUC_id == filtro.SucursalIdFiltro.Value);

            if (!string.IsNullOrEmpty(filtro.DiaSemanaFiltro))
                query = query.Where(x => x.HOR_diaSemana == filtro.DiaSemanaFiltro);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<HorarioAtencionDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<HorarioAtencionDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.HorariosAtencion.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<HorarioAtencionDataModel> AddAsync(HorarioAtencionDataModel model)
        {
            var entity = model.ToEntity();
            await _context.HorariosAtencion.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<HorarioAtencionDataModel> UpdateAsync(HorarioAtencionDataModel model)
        {
            var entity = model.ToEntity();
            _context.HorariosAtencion.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.HorariosAtencion.FindAsync(id);
            if (entity == null) return false;

            _context.HorariosAtencion.Remove(entity);
            return true;
        }
    }
}