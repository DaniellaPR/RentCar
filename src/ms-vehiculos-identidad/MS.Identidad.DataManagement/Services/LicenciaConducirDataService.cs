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
    public class LicenciaConducirDataService : ILicenciaConducirDataService
    {
        private readonly IdentidadDbContext _context;

        public LicenciaConducirDataService(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<LicenciaConducirDataModel>> GetPagedAsync(LicenciaConducirFiltroDataModel filtro)
        {
            var query = _context.LicenciasConducir.AsQueryable();

            if (filtro.ClienteIdFiltro.HasValue)
                query = query.Where(x => x.CLI_id == filtro.ClienteIdFiltro.Value);

            if (!string.IsNullOrEmpty(filtro.NumeroFiltro))
                query = query.Where(x => x.LIC_numero.Contains(filtro.NumeroFiltro));

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<LicenciaConducirDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<LicenciaConducirDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.LicenciasConducir.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<LicenciaConducirDataModel> AddAsync(LicenciaConducirDataModel model)
        {
            var entity = model.ToEntity();
            await _context.LicenciasConducir.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<LicenciaConducirDataModel> UpdateAsync(LicenciaConducirDataModel model)
        {
            var entity = model.ToEntity();
            _context.LicenciasConducir.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.LicenciasConducir.FindAsync(id);
            if (entity == null) return false;

            _context.LicenciasConducir.Remove(entity);
            return true;
        }
    }
}