using MS.Catalogo.Business.DTOs.CategoriaVehiculo;

namespace MS.Catalogo.Business.Interfaces;

public interface ICategoriaVehiculoService
{
    Task<CategoriaVehiculoResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<CategoriaVehiculoResponse>> GetAllAsync();
    Task<CategoriaVehiculoResponse> CreateAsync(CrearCategoriaVehiculoRequest request);
    Task<CategoriaVehiculoResponse> UpdateAsync(Guid id, ActualizarCategoriaVehiculoRequest request);
    Task DeleteAsync(Guid id, string usuarioModificacion);
}
