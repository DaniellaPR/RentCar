// MS.Identidad.Api/Controllers/v1/AuthController.cs
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Identidad.Api.Models.Common;
using MS.Identidad.Business.DTOs.Auth;
using MS.Identidad.Business.DTOs.UsuarioApp;
using MS.Identidad.Business.Interfaces;

namespace MS.Identidad.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paula-pozo/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        // ─── POST /auth/login ────────────────────────────────────────────────────
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(new ApiResponse<LoginResponse>(result, "Autenticación satisfactoria. Token emitido."));
        }

        // ─── POST /auth/register ─────────────────────────────────────────────────
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<UsuarioAppResponse>>> Register([FromBody] RegistroDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(new ApiResponse<UsuarioAppResponse>(result, "Usuario registrado correctamente."));
        }
    }
}
