using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class TarifaQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public TarifaQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TarifaEntity>> GetByCategoriaIdAsync(Guid categoriaId)
        {
            return await _context.Tarifas
                .Where(x => x.CAT_id == categoriaId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}