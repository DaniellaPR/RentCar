using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.HorarioAtencion;

public class CrearHorarioAtencionRequest
{
    public Guid SUC_id { get; set; }
    public int HOR_diaSemana { get; set; } // Ej: 1=Lunes, 7=Domingo
    public TimeSpan HOR_horaApertura { get; set; }
    public TimeSpan HOR_horaCierre { get; set; }

    [JsonIgnore] public string? HOR_usuarioCreacion { get; set; }
}
