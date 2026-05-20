using MS.Catalogo.Business.DTOs.Sucursal;

namespace MS.Catalogo.Business.Interfaces;

public interface ISucursalService
{
    Task<SucursalResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<SucursalResponse>> GetAllAsync();
    Task<SucursalResponse> CreateAsync(CrearSucursalRequest request);
    Task<SucursalResponse> UpdateAsync(Guid id, ActualizarSucursalRequest request);
    Task DeleteAsync(Guid id, string usuarioModificacion);
}
