using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Mantenimiento;

public class CrearMantenimientoRequest
{
    public Guid VEH_id { get; set; }
    public DateTime MAN_fecha { get; set; }
    
    public string MAN_descripcion { get; set; } = null!;
    public decimal MAN_costo { get; set; }

    [JsonIgnore] public string? MAN_usuarioCreacion { get; set; }
}
