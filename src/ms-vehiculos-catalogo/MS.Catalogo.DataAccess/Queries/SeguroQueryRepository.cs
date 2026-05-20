using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class SeguroQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public SeguroQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SeguroEntity>> GetAllAsync()
        {
            return await _context.Seguros
                .AsNoTracking()
                .ToListAsync();
        }
    }
}