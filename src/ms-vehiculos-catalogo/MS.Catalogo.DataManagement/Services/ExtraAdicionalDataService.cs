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
    public class ExtraAdicionalDataService : IExtraAdicionalDataService
    {
        private readonly CatalogoDbContext _context;

        public ExtraAdicionalDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<ExtraAdicionalDataModel>> GetPagedAsync(ExtraAdicionalFiltroDataModel filtro)
        {
            var query = _context.ExtrasAdicionales.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.NombreFiltro))
                query = query.Where(x => x.EXT_nombre.Contains(filtro.NombreFiltro));

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<ExtraAdicionalDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<ExtraAdicionalDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.ExtrasAdicionales.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<ExtraAdicionalDataModel> AddAsync(ExtraAdicionalDataModel model)
        {
            var entity = model.ToEntity();
            await _context.ExtrasAdicionales.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<ExtraAdicionalDataModel> UpdateAsync(ExtraAdicionalDataModel model)
        {
            var entity = model.ToEntity();
            _context.ExtrasAdicionales.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.ExtrasAdicionales.FindAsync(id);
            if (entity == null) return false;

            _context.ExtrasAdicionales.Remove(entity);
            return true;
        }
    }
}