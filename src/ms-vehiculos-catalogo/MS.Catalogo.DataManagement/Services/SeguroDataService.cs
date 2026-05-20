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
    public class SeguroDataService : ISeguroDataService
    {
        private readonly CatalogoDbContext _context;

        public SeguroDataService(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<SeguroDataModel>> GetPagedAsync(SeguroFiltroDataModel filtro)
        {
            var query = _context.Seguros.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.NombreFiltro))
                query = query.Where(x => x.SEG_nombre.Contains(filtro.NombreFiltro));

            if (!string.IsNullOrEmpty(filtro.CoberturaFiltro))
                query = query.Where(x => x.SEG_cobertura == filtro.CoberturaFiltro);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<SeguroDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<SeguroDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Seguros.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<SeguroDataModel> AddAsync(SeguroDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Seguros.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<SeguroDataModel> UpdateAsync(SeguroDataModel model)
        {
            var entity = model.ToEntity();
            _context.Seguros.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Seguros.FindAsync(id);
            if (entity == null) return false;

            _context.Seguros.Remove(entity);
            return true;
        }
    }
}