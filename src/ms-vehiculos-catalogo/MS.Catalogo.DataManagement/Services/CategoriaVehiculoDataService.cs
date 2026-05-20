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
    public class CategoriaVehiculoDataService : ICategoriaVehiculoDataService
    {
        private readonly CatalogoDbContext _context;

        public CategoriaVehiculoDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<CategoriaVehiculoDataModel>> GetPagedAsync(CategoriaVehiculoFiltroDataModel filtro)
        {
            // CORRECCIÓN: Usando CategoriasVehiculo tal como está en tu DbContext
            var query = _context.CategoriasVehiculo.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.NombreFiltro))
            {
                query = query.Where(x => x.CAT_nombre.Contains(filtro.NombreFiltro));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<CategoriaVehiculoDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<CategoriaVehiculoDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.CategoriasVehiculo.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<CategoriaVehiculoDataModel> AddAsync(CategoriaVehiculoDataModel model)
        {
            var entity = model.ToEntity();
            await _context.CategoriasVehiculo.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<CategoriaVehiculoDataModel> UpdateAsync(CategoriaVehiculoDataModel model)
        {
            var entity = model.ToEntity();
            _context.CategoriasVehiculo.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.CategoriasVehiculo.FindAsync(id);
            if (entity == null) return false;

            _context.CategoriasVehiculo.Remove(entity);
            return true;
        }
    }
}