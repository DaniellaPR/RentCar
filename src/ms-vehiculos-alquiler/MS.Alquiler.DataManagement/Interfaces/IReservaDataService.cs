using MS.Alquiler.DataManagement.Common;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Interfaces
{
    /// <summary>
    /// AMPLIADO: Se añade GetByVehiculoEnRangoAsync para que el Business pueda validar
    /// disponibilidad de fechas. Esto es requerido por el endpoint /vehiculos/{id}/disponibilidad
    /// del contrato del Booking (vehiculos-api.txt).
    /// </summary>
    public interface IReservaDataService
    {
        Task<DataPagedResult<ReservaDataModel>> GetPagedAsync(ReservaFiltroDataModel filtro);
        Task<ReservaDataModel?> GetByIdAsync(Guid id);
        Task<ReservaDataModel> AddAsync(ReservaDataModel model);
        Task<ReservaDataModel> UpdateAsync(ReservaDataModel model);
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Devuelve reservas activas (no canceladas) de un vehículo que se solapan con el rango dado.
        /// Usado para validar disponibilidad antes de crear una reserva.
        /// </summary>
        Task<IEnumerable<ReservaDataModel>> GetByVehiculoEnRangoAsync(
            Guid vehiculoId,
            DateTime fechaInicio,
            DateTime fechaFin);
    }
}