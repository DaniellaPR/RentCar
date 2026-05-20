using System.Text.Json.Serialization;

namespace MS.Identidad.Business.DTOs.Rol;

public class ActualizarRolRequest
{
    [JsonIgnore] public Guid ROL_id { get; set; }
    public string ROL_nombre { get; set; } = null!;
    public string? ROL_descripcion { get; set; }
}
