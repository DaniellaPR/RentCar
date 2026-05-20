using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class SucursalQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public SucursalQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SucursalEntity>> GetAllAsync()
        {
            return await _context.Sucursales
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SucursalEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Sucursales
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SUC_id == id);
        }
    }
}