using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Mantenimiento;

public class ActualizarMantenimientoRequest
{
    [JsonIgnore] public Guid MAN_id { get; set; }
    public Guid VEH_id { get; set; }
    public DateTime MAN_fecha { get; set; }
    
    public string MAN_descripcion { get; set; } = null!;
    public decimal MAN_costo { get; set; }

    // ?? Campos de auditor�a
    [JsonIgnore] public string? MAN_usuarioModificacion { get; set; }
}
