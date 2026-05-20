// PARTE 5 � MS.Catalogo.Business/DTOs/Sucursal/ActualizarSucursalRequest.cs
// CORRECCI�N: SUC_telefono ? SUC_coordenadas para alinearse con SucursalDataModel y el mapper.

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Sucursal;

public class ActualizarSucursalRequest
{
    [JsonIgnore] public Guid SUC_id { get; set; }
    public string SUC_nombre { get; set; } = null!;
    public string SUC_direccion { get; set; } = null!;
    public string SUC_ciudad { get; set; } = null!;
    public string? SUC_coordenadas { get; set; }

    // Auditor�a
    [JsonIgnore] public string? SUC_usuarioModificacion { get; set; }
}
