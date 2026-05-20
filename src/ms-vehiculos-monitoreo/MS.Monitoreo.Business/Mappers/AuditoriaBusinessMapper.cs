// PARTE 5 — MS.Monitoreo.Business/Mappers/AuditoriaBusinessMapper.cs
// CORRECCIÓN CRÍTICA: AuditoriaDataModel usa AUD_id/AUD_nombreTabla/AUD_operacion/AUD_usuario/
//                    AUD_fecha/AUD_detalleJsonb. La versión anterior usaba AudId/AudNombreTabla etc.

using MS.Monitoreo.Business.DTOs.Auditoria;
using MS.Monitoreo.DataManagement.Models;

namespace MS.Monitoreo.Business.Mappers;

public static class AuditoriaBusinessMapper
{
    public static AuditoriaDataModel ToDataModel(this CrearAuditoriaRequest request)
    {
        return new AuditoriaDataModel
        {
            AUD_id = Guid.NewGuid(),
            AUD_nombreTabla = request.AUD_nombreTabla,
            AUD_operacion = request.AUD_operacion,
            AUD_usuario = request.AUD_usuario,
            AUD_detalleJsonb = request.AUD_detalleJsonb,
            AUD_fecha = DateTime.UtcNow
        };
    }

    public static AuditoriaResponse ToResponse(this AuditoriaDataModel model)
    {
        return new AuditoriaResponse
        {
            AUD_id = model.AUD_id,
            AUD_nombreTabla = model.AUD_nombreTabla,
            AUD_operacion = model.AUD_operacion,
            AUD_usuario = model.AUD_usuario,
            AUD_fecha = model.AUD_fecha,
            AUD_detalleJsonb = model.AUD_detalleJsonb
        };
    }
}