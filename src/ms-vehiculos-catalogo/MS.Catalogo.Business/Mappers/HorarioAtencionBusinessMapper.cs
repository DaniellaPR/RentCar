using MS.Catalogo.Business.DTOs.HorarioAtencion;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class HorarioAtencionBusinessMapper
{
    public static HorarioAtencionDataModel ToDataModel(this CrearHorarioAtencionRequest request)
    {
        return new HorarioAtencionDataModel
        {
            HOR_id = Guid.NewGuid(),
            SUC_id = request.SUC_id,
            HOR_diaSemana = request.HOR_diaSemana.ToString(),
            HOR_apertura = request.HOR_horaApertura,
            HOR_cierre = request.HOR_horaCierre,
            HOR_usuarioCreacion = request.HOR_usuarioCreacion,
            HOR_fechaCreacion = DateTime.UtcNow
        };
    }

    public static HorarioAtencionResponse ToResponse(this HorarioAtencionDataModel model)
    {
        return new HorarioAtencionResponse
        {
            HOR_id = model.HOR_id,
            SUC_id = model.SUC_id,
            HOR_diaSemana = int.Parse(model.HOR_diaSemana),
            HOR_horaApertura = model.HOR_apertura,
            HOR_horaCierre = model.HOR_cierre
        };
    }
}
