// PARTE 5 — MS.Identidad.Business/DTOs/Cliente/ClienteResponse.cs
// CORRECCIÓN: ClienteDataModel usa CLI_id, CLI_nombres, CLI_apellidos, CLI_cedula, CLI_telefono.
//             Se alinean los nombres del DTO con los del DataModel para evitar mismatch en mappers.

namespace MS.Identidad.Business.DTOs.Cliente;

public class ClienteResponse
{
    public Guid CLI_id { get; set; }
    public string CLI_nombres { get; set; } = null!;
    public string CLI_apellidos { get; set; } = null!;
    public string CLI_cedula { get; set; } = null!;
    public string? CLI_telefono { get; set; }
}
