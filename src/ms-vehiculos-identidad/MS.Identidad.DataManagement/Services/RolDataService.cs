using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataManagement.Common;
using MS.Identidad.DataManagement.Interfaces;
using MS.Identidad.DataManagement.Mappers;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Services
{
    public class RolDataService : IRolDataService
    {
        private readonly IdentidadDbContext _context;

        public RolDataService(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<RolDataModel>> GetPagedAsync(RolFiltroDataModel filtro)
        {
            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.NombreFiltro))
                query = query.Where(x => x.ROL_nombre.Contains(filtro.NombreFiltro));

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<RolDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<RolDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Roles.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<RolDataModel> AddAsync(RolDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Roles.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<RolDataModel> UpdateAsync(RolDataModel model)
        {
            var entity = model.ToEntity();
            _context.Roles.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null) return false;

            _context.Roles.Remove(entity);
            return true;
        }
    }
}