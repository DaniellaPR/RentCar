// MS.Catalogo.Business/Interfaces/IVehiculoService.cs
using MS.Catalogo.Business.DTOs.Vehiculo;

namespace MS.Catalogo.Business.Interfaces;

public interface IVehiculoService
{
    Task<VehiculoResponse>              GetByIdAsync(Guid id);
    Task<IEnumerable<VehiculoResponse>> GetAllAsync();
    Task<IEnumerable<VehiculoResponse>> GetDisponiblesAsync();

    /// <summary>
    /// Verifica si el vehículo está disponible en el rango de fechas.
    /// Llama al ms-alquiler por gRPC para consultar solapamientos de reservas.
    /// Por ahora (Reto 2) hace la consulta REST interna vía IReservaService injected
    /// si ambos MSs están en el mismo proceso, o devuelve VEH_disponibilidad si no.
    /// </summary>
    Task<bool> GetDisponibilidadAsync(Guid vehiculoId, DateTime fechaInicio, DateTime fechaFin);

    Task<VehiculoResponse> CreateAsync(CrearVehiculoRequest request);
    Task<VehiculoResponse> UpdateAsync(Guid id, ActualizarVehiculoRequest request);
    Task                   DeleteAsync(Guid id, string usuarioModificacion);
}
