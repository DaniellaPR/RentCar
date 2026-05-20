using MS.Catalogo.Business.DTOs.Tarifa;

namespace MS.Catalogo.Business.Interfaces;

public interface ITarifaService
{
    Task<TarifaResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<TarifaResponse>> GetAllAsync();
    Task<TarifaResponse> CreateAsync(CrearTarifaRequest request);
    Task<TarifaResponse> UpdateAsync(Guid id, ActualizarTarifaRequest request);
    Task DeleteAsync(Guid id, string usuarioModificacion);
}
