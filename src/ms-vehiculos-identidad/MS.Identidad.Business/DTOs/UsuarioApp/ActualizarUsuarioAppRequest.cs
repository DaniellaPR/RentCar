// PARTE 5 — MS.Identidad.Business/DTOs/UsuarioApp/ActualizarUsuarioAppRequest.cs

using System.Text.Json.Serialization;

namespace MS.Identidad.Business.DTOs.UsuarioApp;

public class ActualizarUsuarioAppRequest
{
    [JsonIgnore] public Guid USU_id { get; set; }
    public Guid ROL_id { get; set; }
    public string USU_email { get; set; } = null!;
    public string USU_estado { get; set; } = "ACTIVO";

    // Auditoría
    [JsonIgnore] public string? USU_usuarioModificacion { get; set; }
}
