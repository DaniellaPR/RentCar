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
    public class TarifaDataService : ITarifaDataService
    {
        private readonly CatalogoDbContext _context;

        public TarifaDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<TarifaDataModel>> GetPagedAsync(TarifaFiltroDataModel filtro)
        {
            var query = _context.Tarifas.AsQueryable();

            if (filtro.CategoriaIdFiltro.HasValue)
                query = query.Where(x => x.CAT_id == filtro.CategoriaIdFiltro.Value);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<TarifaDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<TarifaDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Tarifas.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<TarifaDataModel> AddAsync(TarifaDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Tarifas.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<TarifaDataModel> UpdateAsync(TarifaDataModel model)
        {
            var entity = model.ToEntity();
            _context.Tarifas.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Tarifas.FindAsync(id);
            if (entity == null) return false;

            _context.Tarifas.Remove(entity);
            return true;
        }
    }
}