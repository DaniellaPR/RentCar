// MS.Alquiler.Business/Interfaces/IReservaService.cs
// Sin cambios de firma — se deja igual que ya estaba con DeleteAsync incluido.
// El ReservaService debe implementarlo.

using MS.Alquiler.Business.DTOs.Reserva;

namespace MS.Alquiler.Business.Interfaces;

public interface IReservaService
{
    Task<ReservaResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<ReservaResponse>> GetAllAsync();
    Task<IEnumerable<ReservaResponse>> GetByClienteAsync(Guid clienteId);
    Task<bool> GetDisponibilidadAsync(Guid vehiculoId, DateTime fechaRetiro, DateTime fechaEntrega);
    Task<ReservaResponse> CreateAsync(CrearReservaRequest request);
    Task<ReservaResponse> UpdateAsync(Guid id, ActualizarReservaRequest request);
    Task CancelarReservaAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
}
