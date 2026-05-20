// PARTE 5 — MS.Identidad.Business/DTOs/Cliente/ActualizarClienteRequest.cs

using System.Text.Json.Serialization;

namespace MS.Identidad.Business.DTOs.Cliente;

public class ActualizarClienteRequest
{
    [JsonIgnore] public Guid CLI_id { get; set; }
    public string CLI_nombres { get; set; } = null!;
    public string CLI_apellidos { get; set; } = null!;
    public string CLI_cedula { get; set; } = null!;
    public string? CLI_telefono { get; set; }

    // Auditoría
    [JsonIgnore] public string? CLI_usuarioModificacion { get; set; }
}
