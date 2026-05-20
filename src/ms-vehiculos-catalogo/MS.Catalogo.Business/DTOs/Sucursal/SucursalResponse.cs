// PARTE 5 — MS.Catalogo.Business/DTOs/Sucursal/SucursalResponse.cs
// CORRECCIÓN: Añadidos SUC_coordenadas y SUC_estado que SucursalBusinessMapper.ToResponse() mapea.
//             Eliminado SUC_telefono (no existe en SucursalDataModel; el DataModel usa SUC_coordenadas).

namespace MS.Catalogo.Business.DTOs.Sucursal;

public class SucursalResponse
{
    public Guid SUC_id { get; set; }
    public string SUC_nombre { get; set; } = null!;
    public string SUC_direccion { get; set; } = null!;
    public string SUC_ciudad { get; set; } = null!;
    public string? SUC_coordenadas { get; set; }
    public string SUC_estado { get; set; } = "ACTIVO";
}
