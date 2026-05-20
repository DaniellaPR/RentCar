// PARTE 5 — MS.Alquiler.Business/Interfaces/IPagoService.cs
// CORRECCIÓN: Tipos DTOs alineados con PagoDataModel.

using MS.Alquiler.Business.DTOs.Pago;

namespace MS.Alquiler.Business.Interfaces;

public interface IPagoService
{
    Task<PagoResponse> GetByIdAsync(Guid id);
    /// <summary>Lista todos los pagos de una reserva.</summary>
    Task<IEnumerable<PagoResponse>> GetAllByReservaIdAsync(Guid reservaId);
    Task<PagoResponse> CreateAsync(CrearPagoRequest request);
    Task<PagoResponse> UpdateAsync(Guid id, ActualizarPagoRequest request);
}