// MS.Identidad.Business/Services/AuthService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MS.Identidad.Business.DTOs.Auth;
using MS.Identidad.Business.Exceptions;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.Validators;
using MS.Identidad.Business.DTOs.UsuarioApp;
using MS.Identidad.DataManagement.Interfaces;
using MS.Identidad.Business.Models.Settings;

namespace MS.Identidad.Business.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork  _unitOfWork;
    private readonly JwtSettings  _jwtSettings;

    public AuthService(IUnitOfWork unitOfWork, IOptions<JwtSettings> jwtOptions)
    {
        _unitOfWork  = unitOfWork;
        _jwtSettings = jwtOptions.Value;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        AuthValidator.ValidarLogin(request);

        // Busca por email directo (evita cargar 1000 registros en memoria)
        var usuario = await _unitOfWork.UsuariosApp.GetByEmailAsync(request.Correo)
            ?? throw new UnauthorizedException("Credenciales incorrectas.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.USU_passwordHash))
            throw new UnauthorizedException("Credenciales incorrectas.");

        if (usuario.USU_estado != "ACTIVO")
            throw new UnauthorizedException("La cuenta está inactiva.");

        var rol = await _unitOfWork.Roles.GetByIdAsync(usuario.ROL_id);

        // ─── Generación real del JWT ─────────────────────────────────────────────
        var token = GenerarJwt(usuario.USU_id, usuario.USU_email, rol?.ROL_nombre ?? "CLIENTE");

        return new LoginResponse
        {
            Token     = token,
            UsuarioId = usuario.USU_id,
            Nombre    = usuario.USU_email,
            Rol       = rol?.ROL_nombre ?? "CLIENTE"
        };
    }

    public async Task<UsuarioAppResponse> RegisterAsync(RegistroDto request)
    {
        var existente = await _unitOfWork.UsuariosApp.GetByEmailAsync(request.Correo);
        if (existente != null)
            throw new BusinessException($"Ya existe un usuario con el correo {request.Correo}.");

        var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var nuevoUsuario = new MS.Identidad.DataManagement.Models.UsuarioAppDataModel
        {
            USU_id           = Guid.NewGuid(),
            ROL_id           = request.ROL_id,
            USU_email        = request.Correo.ToLower(),
            USU_passwordHash = hashPassword,
            USU_estado       = "ACTIVO",
            USU_fechaCreacion = DateTime.UtcNow
        };

        var creado = await _unitOfWork.UsuariosApp.AddAsync(nuevoUsuario);
        await _unitOfWork.CommitAsync();

        return new UsuarioAppResponse
        {
            USU_id    = creado.USU_id,
            ROL_id    = creado.ROL_id,
            USU_email = creado.USU_email,
            USU_estado = creado.USU_estado
        };
    }

    // ─── Generación de JWT ───────────────────────────────────────────────────────
    private string GenerarJwt(Guid usuarioId, string email, string rol)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,   usuarioId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role,               rol),
            new Claim(JwtRegisteredClaimNames.Jti,   Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64)
        };

        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer:             _jwtSettings.Issuer,
            audience:           _jwtSettings.Audience,
            claims:             claims,
            expires:            DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
