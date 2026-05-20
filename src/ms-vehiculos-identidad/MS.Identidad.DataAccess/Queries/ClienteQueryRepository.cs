using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Queries
{
    public class ClienteQueryRepository
    {
        private readonly IdentidadDbContext _context;

        public ClienteQueryRepository(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteEntity>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(c => c.Licencias)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ClienteEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes
                .Include(c => c.Licencias)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CLI_id == id);
        }

        public async Task<ClienteEntity?> GetByCedulaAsync(string cedula)
        {
            return await _context.Clientes
                .Include(c => c.Licencias)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CLI_cedula == cedula);
        }
    }
}