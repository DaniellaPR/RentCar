// PARTE 5 — MS.Alquiler.Business/Interfaces/IReservaDetalleService.cs
// CORRECCIÓN: Tipos DTOs alineados con ReservaDetalleDataModel.

using MS.Alquiler.Business.DTOs.ReservaDetalle;

namespace MS.Alquiler.Business.Interfaces;

public interface IReservaDetalleService
{
    Task<ReservaDetalleResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<ReservaDetalleResponse>> GetByReservaAsync(Guid reservaId);
    Task<ReservaDetalleResponse> CreateAsync(CrearReservaDetalleRequest request);
    Task<ReservaDetalleResponse> UpdateAsync(Guid id, ActualizarReservaDetalleRequest request);
    Task DeleteAsync(Guid id);
}