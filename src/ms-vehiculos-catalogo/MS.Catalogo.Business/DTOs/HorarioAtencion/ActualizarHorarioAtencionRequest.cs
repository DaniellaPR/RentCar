using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.HorarioAtencion;

public class ActualizarHorarioAtencionRequest
{
    [JsonIgnore] public Guid HOR_id { get; set; }
    public Guid SUC_id { get; set; }
    public int HOR_diaSemana { get; set; }
    public TimeSpan HOR_horaApertura { get; set; }
    public TimeSpan HOR_horaCierre { get; set; }

    // ?? Campos de auditor�a
    [JsonIgnore] public string? HOR_usuarioModificacion { get; set; }
}
