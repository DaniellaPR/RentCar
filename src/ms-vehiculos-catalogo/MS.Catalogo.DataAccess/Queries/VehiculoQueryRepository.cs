using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Queries
{
    public class VehiculoQueryRepository
    {
        private readonly CatalogoDbContext _context;

        public VehiculoQueryRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehiculoEntity>> GetAllDisponiblesAsync()
        {
            return await _context.Vehiculos
                .Include(v => v.Categoria)
                .Include(v => v.Sucursal)
                .Where(v => v.VEH_estado == "DISPONIBLE")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<VehiculoEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Vehiculos
                .Include(v => v.Categoria)
                .Include(v => v.Sucursal)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VEH_id == id);
        }

        public IQueryable<VehiculoEntity> GetQueryable()
        {
            // Útil para aplicar filtros dinámicos (búsqueda, paginación) desde la capa Business
            return _context.Vehiculos
                .Include(v => v.Categoria)
                .Include(v => v.Sucursal)
                .AsNoTracking();
        }
    }
}