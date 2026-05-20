// PARTE 5 � MS.Catalogo.Business/DTOs/Sucursal/CrearSucursalRequest.cs
// CORRECCI�N: SucursalDataModel no tiene SUC_telefono; tiene SUC_coordenadas.
//             SucursalBusinessMapper.ToDataModel() asigna SUC_coordenadas.

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Sucursal;

public class CrearSucursalRequest
{
    public string SUC_nombre { get; set; } = null!;
    public string SUC_direccion { get; set; } = null!;
    public string SUC_ciudad { get; set; } = null!;
    public string? SUC_coordenadas { get; set; }

    // Auditor�a
    [JsonIgnore] public string? SUC_usuarioCreacion { get; set; }
}
