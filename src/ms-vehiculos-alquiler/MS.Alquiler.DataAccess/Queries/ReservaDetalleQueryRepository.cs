using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataAccess.Entities;

namespace MS.Alquiler.DataAccess.Queries
{
    public class ReservaDetalleQueryRepository
    {
        private readonly AlquilerDbContext _context;

        public ReservaDetalleQueryRepository(AlquilerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservaDetalleEntity>> GetByReservaIdAsync(Guid reservaId)
        {
            return await _context.ReservaDetalles
                .Where(x => x.RES_id == reservaId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}