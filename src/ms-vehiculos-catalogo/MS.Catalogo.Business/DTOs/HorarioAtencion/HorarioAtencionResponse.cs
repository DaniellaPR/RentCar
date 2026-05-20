namespace MS.Catalogo.Business.DTOs.HorarioAtencion;

public class HorarioAtencionResponse
{
    public Guid HOR_id { get; set; }
    public Guid SUC_id { get; set; }
    public int HOR_diaSemana { get; set; }
    public TimeSpan HOR_horaApertura { get; set; }
    public TimeSpan HOR_horaCierre { get; set; }
}
