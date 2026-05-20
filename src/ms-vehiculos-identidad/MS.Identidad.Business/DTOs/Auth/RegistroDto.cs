// ─────────────────────────────────────────────────────────────────────────────
// MS.Identidad.Business/DTOs/Auth/RegistroDto.cs  ← NUEVO (faltaba)
// ─────────────────────────────────────────────────────────────────────────────
namespace MS.Identidad.Business.DTOs.Auth;

public class RegistroDto
{
    public string Correo   { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid   ROL_id   { get; set; }
}