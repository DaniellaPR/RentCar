using MS.Identidad.Business.DTOs.Rol;

namespace MS.Identidad.Business.Interfaces;

public interface IRolService
{
    Task<RolResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<RolResponse>> GetAllAsync();
    Task<RolResponse> CreateAsync(CrearRolRequest request);
    Task<RolResponse> UpdateAsync(Guid id, ActualizarRolRequest request);
    Task<bool> DeleteAsync(Guid id);
}
