using MS.Monitoreo.DataAccess.Entities;
using MS.Monitoreo.DataManagement.Models;

namespace MS.Monitoreo.DataManagement.Mappers
{
    public static class AuditoriaDataMapper
    {
        public static AuditoriaDataModel ToDataModel(this AuditoriaEntity entity)
        {
            if (entity == null) return null!;

            return new AuditoriaDataModel
            {
                AUD_id = entity.AUD_id,
                AUD_nombreTabla = entity.AUD_nombreTabla,
                AUD_operacion = entity.AUD_operacion,
                AUD_usuario = entity.AUD_usuario,
                AUD_fecha = entity.AUD_fecha ?? DateTime.UtcNow,
                AUD_detalleJsonb = entity.AUD_detalleJsonb
            };
        }

        public static AuditoriaEntity ToEntity(this AuditoriaDataModel model)
        {
            if (model == null) return null!;

            return new AuditoriaEntity
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
}