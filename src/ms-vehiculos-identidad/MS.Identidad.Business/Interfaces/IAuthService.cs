// MS.Identidad.Business/Interfaces/IAuthService.cs
using MS.Identidad.Business.DTOs.Auth;
using MS.Identidad.Business.DTOs.UsuarioApp;

namespace MS.Identidad.Business.Interfaces;

public interface IAuthService
{
    Task<LoginResponse>       LoginAsync(LoginRequest request);
    Task<UsuarioAppResponse>  RegisterAsync(RegistroDto request);   // ← FIX: era RegisterAsync(CrearUsuarioAppRequest)
}




