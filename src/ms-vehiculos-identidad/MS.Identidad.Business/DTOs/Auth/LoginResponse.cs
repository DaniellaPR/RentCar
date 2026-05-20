namespace MS.Identidad.Business.DTOs.Auth;

 public class LoginResponse
 {
     public string Token     { get; set; } = string.Empty;  // JWT real, no placeholder
     public Guid   UsuarioId { get; set; }
     public string Nombre    { get; set; } = string.Empty;
     public string Rol       { get; set; } = string.Empty;
}
