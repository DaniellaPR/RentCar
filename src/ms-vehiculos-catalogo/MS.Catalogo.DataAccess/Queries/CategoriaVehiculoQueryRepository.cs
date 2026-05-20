using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class CategoriaVehiculoQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public CategoriaVehiculoQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaVehiculoEntity>> GetAllAsync()
        {
            return await _context.CategoriasVehiculo
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CategoriaVehiculoEntity?> GetByIdAsync(Guid id)
        {
            return await _context.CategoriasVehiculo
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CAT_id == id);
        }
    }
}