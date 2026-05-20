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
    public class MantenimientoDataService : IMantenimientoDataService
    {
        private readonly CatalogoDbContext _context;

        public MantenimientoDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<MantenimientoDataModel>> GetPagedAsync(MantenimientoFiltroDataModel filtro)
        {
            var query = _context.Mantenimientos.AsQueryable();

            if (filtro.VehiculoIdFiltro.HasValue)
                query = query.Where(x => x.VEH_id == filtro.VehiculoIdFiltro.Value);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<MantenimientoDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<MantenimientoDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Mantenimientos.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<MantenimientoDataModel> AddAsync(MantenimientoDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Mantenimientos.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<MantenimientoDataModel> UpdateAsync(MantenimientoDataModel model)
        {
            var entity = model.ToEntity();
            _context.Mantenimientos.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Mantenimientos.FindAsync(id);
            if (entity == null) return false;

            _context.Mantenimientos.Remove(entity);
            return true;
        }
    }
}