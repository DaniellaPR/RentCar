using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Queries
{
    public class LicenciaConducirQueryRepository
    {
        private readonly IdentidadDbContext _context;

        public LicenciaConducirQueryRepository(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LicenciaConducirEntity>> GetByClienteIdAsync(Guid clienteId)
        {
            return await _context.LicenciasConducir
                .Where(l => l.CLI_id == clienteId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}