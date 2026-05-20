using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Queries
{
    public class RolQueryRepository
    {
        private readonly IdentidadDbContext _context;

        public RolQueryRepository(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RolEntity>> GetAllAsync()
        {
            return await _context.Roles.AsNoTracking().ToListAsync();
        }
    }
}