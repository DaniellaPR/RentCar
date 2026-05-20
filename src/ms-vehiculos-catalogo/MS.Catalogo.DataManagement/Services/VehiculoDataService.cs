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
    public class VehiculoDataService : IVehiculoDataService
    {
        private readonly CatalogoDbContext _context;

        public VehiculoDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<VehiculoDataModel>> GetPagedAsync(VehiculoFiltroDataModel filtro)
        {
            var query = _context.Vehiculos.AsQueryable();

            if (filtro.CategoriaIdFiltro.HasValue)
                query = query.Where(x => x.CAT_id == filtro.CategoriaIdFiltro.Value);

            if (filtro.SucursalIdFiltro.HasValue)
                query = query.Where(x => x.SUC_id == filtro.SucursalIdFiltro.Value);

            if (!string.IsNullOrEmpty(filtro.PlacaFiltro))
                query = query.Where(x => x.VEH_placa.Contains(filtro.PlacaFiltro));

            if (!string.IsNullOrEmpty(filtro.EstadoFiltro))
                query = query.Where(x => x.VEH_estado == filtro.EstadoFiltro);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<VehiculoDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<VehiculoDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Vehiculos.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<VehiculoDataModel> AddAsync(VehiculoDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Vehiculos.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<VehiculoDataModel> UpdateAsync(VehiculoDataModel model)
        {
            var entity = model.ToEntity();
            _context.Vehiculos.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Vehiculos.FindAsync(id);
            if (entity == null) return false;

            _context.Vehiculos.Remove(entity);
            return true;
        }
    }
}