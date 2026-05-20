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
    public class ClienteDataService : IClienteDataService
    {
        private readonly IdentidadDbContext _context;

        public ClienteDataService(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<ClienteDataModel>> GetPagedAsync(ClienteFiltroDataModel filtro)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.CedulaFiltro))
                query = query.Where(x => x.CLI_cedula.Contains(filtro.CedulaFiltro));

            if (!string.IsNullOrEmpty(filtro.ApellidosFiltro))
                query = query.Where(x => x.CLI_apellidos.Contains(filtro.ApellidosFiltro));

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<ClienteDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<ClienteDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<ClienteDataModel> AddAsync(ClienteDataModel model)
        {
            var entity = model.ToEntity();
            await _context.Clientes.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<ClienteDataModel> UpdateAsync(ClienteDataModel model)
        {
            var entity = model.ToEntity();
            _context.Clientes.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity == null) return false;

            _context.Clientes.Remove(entity);
            return true;
        }
    }
}