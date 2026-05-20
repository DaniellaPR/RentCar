using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class MantenimientoQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public MantenimientoQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MantenimientoEntity>> GetByVehiculoIdAsync(Guid vehiculoId)
        {
            return await _context.Mantenimientos
                .Where(x => x.VEH_id == vehiculoId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}