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
    public class SucursalDataService : ISucursalDataService
    {
        private readonly CatalogoDbContext _context;

        public SucursalDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<SucursalDataModel>> GetPagedAsync(SucursalFiltroDataModel filtro)
        {
            var query = _context.Sucursales.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.CiudadFiltro))
                query = query.Where(x => x.SUC_ciudad.Contains(filtro.CiudadFiltro));

            if (!string.IsNullOrEmpty(filtro.NombreFiltro))
                query = query.Where(x => x.SUC_nombre.Contains(filtro.NombreFiltro));

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<SucursalDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<SucursalDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Sucursales.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<SucursalDataModel> AddAsync(SucursalDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Sucursales.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<SucursalDataModel> UpdateAsync(SucursalDataModel model)
        {
            var entity = model.ToEntity();
            _context.Sucursales.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Sucursales.FindAsync(id);
            if (entity == null) return false;

            _context.Sucursales.Remove(entity);
            return true;
        }
    }
}