// PARTE 5 � MS.Catalogo.Business/DTOs/Vehiculo/CrearVehiculoRequest.cs
// CORRECCI�N: A�adido VEH_imagenUrl que VehiculoBusinessMapper.ToDataModel() ya asigna.
//             VEH_kilometraje a decimal alineado con DataModel.

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Vehiculo;

public class CrearVehiculoRequest
{
    public Guid CAT_id { get; set; }
    public Guid SUC_id { get; set; }
    public string VEH_placa { get; set; } = null!;
    public string VEH_marca { get; set; } = null!;
    public string VEH_modelo { get; set; } = null!;
    public int VEH_anio { get; set; }
    public string? VEH_color { get; set; }
    /// <summary>Decimal alineado con VehiculoDataModel.</summary>
    public decimal VEH_kilometraje { get; set; }
    public bool VEH_disponibilidad { get; set; }
    public string? VEH_imagenUrl { get; set; }

    // Auditor�a � se rellena en el controller con HttpContext, no llega del cliente
    [JsonIgnore] public string? VEH_usuarioCreacion { get; set; }
}
