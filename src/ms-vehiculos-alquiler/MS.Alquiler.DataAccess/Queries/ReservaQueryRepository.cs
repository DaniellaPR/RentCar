using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataAccess.Entities;

namespace MS.Alquiler.DataAccess.Queries
{
    public class ReservaQueryRepository
    {
        private readonly AlquilerDbContext _context;

        public ReservaQueryRepository(AlquilerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservaEntity>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.Detalles)
                .Include(r => r.Pagos)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ReservaEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Reservas
                .Include(r => r.Detalles)
                .Include(r => r.Pagos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RES_id == id);
        }

        public async Task<IEnumerable<ReservaEntity>> GetByClienteIdAsync(Guid clienteId)
        {
            return await _context.Reservas
                .Include(r => r.Detalles)
                .Include(r => r.Pagos)
                .Where(x => x.CLI_id == clienteId)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ReservaEntity> GetQueryable()
        {
            return _context.Reservas
                .Include(r => r.Detalles)
                .Include(r => r.Pagos)
                .AsNoTracking();
        }
    }
}