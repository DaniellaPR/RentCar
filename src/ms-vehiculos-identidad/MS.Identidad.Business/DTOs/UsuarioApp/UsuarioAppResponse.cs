// PARTE 5 — MS.Identidad.Business/DTOs/UsuarioApp/UsuarioAppResponse.cs
// CORRECCIÓN: UsuarioAppDataModel usa USU_id, ROL_id, USU_email, USU_passwordHash, USU_estado (string).
//             El Business usa la misma convención de prefijos para consistencia.
//             UsuarioAppDataMapper (DataManagement) es el que traduce la Entity (que tiene USU_nombre/USU_correo/bool).

namespace MS.Identidad.Business.DTOs.UsuarioApp;

public class UsuarioAppResponse
{
    public Guid USU_id { get; set; }
    public Guid ROL_id { get; set; }
    public string USU_email { get; set; } = null!;
    public string USU_estado { get; set; } = "ACTIVO";
    // NUNCA se devuelve el hash de contraseña
}
