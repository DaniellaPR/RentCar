using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class ExtraAdicionalQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public ExtraAdicionalQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExtraAdicionalEntity>> GetAllAsync()
        {
            return await _context.ExtrasAdicionales
                .AsNoTracking()
                .ToListAsync();
        }
    }
}