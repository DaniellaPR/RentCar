using MS.Identidad.Business.DTOs.UsuarioApp;

namespace MS.Identidad.Business.Interfaces;

public interface IUsuarioAppService
{
    Task<UsuarioAppResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<UsuarioAppResponse>> GetAllAsync();
    Task<UsuarioAppResponse> CreateAsync(CrearUsuarioAppRequest request);
    Task<UsuarioAppResponse> UpdateAsync(Guid id, ActualizarUsuarioAppRequest request);
    Task<bool> DeleteAsync(Guid id);
}
