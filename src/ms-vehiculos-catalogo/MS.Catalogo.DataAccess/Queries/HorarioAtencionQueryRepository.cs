using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class HorarioAtencionQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public HorarioAtencionQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HorarioAtencionEntity>> GetBySucursalIdAsync(Guid sucursalId)
        {
            return await _context.HorariosAtencion
                .Where(x => x.SUC_id == sucursalId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}