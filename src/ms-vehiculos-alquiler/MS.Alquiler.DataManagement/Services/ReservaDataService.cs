using Microsoft.EntityFrameworkCore;
using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataManagement.Common;
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Mappers;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Services
{
    public class ReservaDataService : IReservaDataService
    {
        private readonly AlquilerDbContext _context;

        public ReservaDataService(AlquilerDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<ReservaDataModel>> GetPagedAsync(ReservaFiltroDataModel filtro)
        {
            var query = _context.Reservas.AsQueryable();

            if (filtro.ClienteIdFiltro.HasValue)
                query = query.Where(x => x.CLI_id == filtro.ClienteIdFiltro.Value);

            if (filtro.VehiculoIdFiltro.HasValue)
                query = query.Where(x => x.VEH_id == filtro.VehiculoIdFiltro.Value);

            if (!string.IsNullOrEmpty(filtro.EstadoFiltro))
                query = query.Where(x => x.RES_estado == filtro.EstadoFiltro);

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.RES_fechaCreacion)
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<ReservaDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<ReservaDataModel?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Reservas.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<ReservaDataModel> AddAsync(ReservaDataModel model)
        {
            var entity = model.ToEntity();
            entity.RES_id = Guid.NewGuid();
            entity.RES_fechaReserva = DateTime.UtcNow;
            entity.RES_fechaCreacion = DateTime.UtcNow;
            await _context.Reservas.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<ReservaDataModel> UpdateAsync(ReservaDataModel model)
        {
            var entity = model.ToEntity();
            entity.RES_fechaModificacion = DateTime.UtcNow;
            _context.Reservas.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Reservas.FindAsync(id);
            if (entity == null) return false;
            _context.Reservas.Remove(entity);
            return true;
        }

        /// <summary>
        /// Busca reservas activas del vehículo cuyas fechas se solapan con el rango solicitado.
        /// Un solapamiento ocurre cuando:  inicio < fechaFin  AND  fin > fechaInicio
        /// Los estados CANCELADA y FINALIZADA no bloquean disponibilidad.
        /// </summary>
        public async Task<IEnumerable<ReservaDataModel>> GetByVehiculoEnRangoAsync(
            Guid vehiculoId,
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            var estadosQueBloquean = new[] { "PENDIENTE", "CONFIRMADA" };

            var reservas = await _context.Reservas
                .Where(r =>
                    r.VEH_id == vehiculoId &&
                    estadosQueBloquean.Contains(r.RES_estado) &&
                    r.RES_fechaInicio < fechaFin &&
                    r.RES_fechaFin > fechaInicio)
                .ToListAsync();

            return reservas.Select(r => r.ToDataModel());
        }
    }
}