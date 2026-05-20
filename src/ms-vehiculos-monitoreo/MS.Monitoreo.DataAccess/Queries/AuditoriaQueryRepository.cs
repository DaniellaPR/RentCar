using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Monitoreo.DataAccess.Context;
using MS.Monitoreo.DataAccess.Entities;

namespace MS.Monitoreo.DataAccess.Queries
{
    public class AuditoriaQueryRepository
    {
        private readonly MonitoreoDbContext _context;

        public AuditoriaQueryRepository(MonitoreoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditoriaEntity>> GetAllAsync()
        {
            return await _context.Auditorias
                .AsNoTracking()
                .OrderByDescending(a => a.AUD_fecha)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditoriaEntity>> GetByTablaAsync(string nombreTabla)
        {
            return await _context.Auditorias
                .Where(a => a.AUD_nombreTabla == nombreTabla)
                .AsNoTracking()
                .OrderByDescending(a => a.AUD_fecha)
                .ToListAsync();
        }
    }
}