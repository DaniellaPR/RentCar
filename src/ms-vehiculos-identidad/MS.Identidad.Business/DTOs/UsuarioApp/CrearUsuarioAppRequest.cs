// PARTE 5 — MS.Identidad.Business/DTOs/UsuarioApp/CrearUsuarioAppRequest.cs
// CORRECCIÓN: Campos alineados con UsuarioAppDataModel (USU_email, ROL_id, USU_estado).
//             Password en texto plano — se hashea en el service antes de persistir.

using System.Text.Json.Serialization;

namespace MS.Identidad.Business.DTOs.UsuarioApp;

public class CrearUsuarioAppRequest
{
    public Guid ROL_id { get; set; }
    public string USU_email { get; set; } = null!;
    /// <summary>Contraseña en texto plano — se hashea en UsuarioAppService antes de persistir.</summary>
    public string Password { get; set; } = null!;

    // Auditoría
    [JsonIgnore] public string? USU_usuarioCreacion { get; set; }
}
