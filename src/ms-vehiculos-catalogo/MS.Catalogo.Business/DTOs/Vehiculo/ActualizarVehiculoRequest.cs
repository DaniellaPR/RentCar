// PARTE 5 � MS.Catalogo.Business/DTOs/Vehiculo/ActualizarVehiculoRequest.cs
// CORRECCI�N: A�adido VEH_imagenUrl que VehiculoService.UpdateAsync() ya asigna.
//             VEH_kilometraje a decimal.

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Vehiculo;

public class ActualizarVehiculoRequest
{
    [JsonIgnore] public Guid VEH_id { get; set; }
    public Guid CAT_id { get; set; }
    public Guid SUC_id { get; set; }
    public string VEH_placa { get; set; } = null!;
    public string VEH_marca { get; set; } = null!;
    public string VEH_modelo { get; set; } = null!;
    public int VEH_anio { get; set; }
    public string? VEH_color { get; set; }
    public decimal VEH_kilometraje { get; set; }
    public bool VEH_disponibilidad { get; set; }
    public string? VEH_imagenUrl { get; set; }

    // Auditora
    [JsonIgnore] public string? VEH_usuarioModificacion { get; set; }
    [JsonIgnore] public string? VEH_modificadoDesdeIp { get; set; }
    [JsonIgnore] public string? VEH_modificadoDesdeServicio { get; set; }
    [JsonIgnore] public string? VEH_modificadoDesdeEquipo { get; set; }
}
