// PARTE 5 — MS.Identidad.Business/DTOs/Cliente/CrearClienteRequest.cs
// CORRECCIÓN: CLI_ prefijos alineados con ClienteDataModel.

using System.Text.Json.Serialization;

namespace MS.Identidad.Business.DTOs.Cliente;

public class CrearClienteRequest
{
    public string CLI_nombres { get; set; } = null!;
    public string CLI_apellidos { get; set; } = null!;
    public string CLI_cedula { get; set; } = null!;
    public string? CLI_telefono { get; set; }

    // Auditoría
    [JsonIgnore] public string? CLI_usuarioCreacion { get; set; }
}
