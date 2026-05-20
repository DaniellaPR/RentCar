using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class HorarioAtencionDataMapper
    {
        public static HorarioAtencionDataModel ToDataModel(this HorarioAtencionEntity entity)
        {
            if (entity == null) return null!;

            return new HorarioAtencionDataModel
            {
                HOR_id = entity.HOR_id,
                SUC_id = entity.SUC_id,
                HOR_diaSemana = entity.HOR_diaSemana,
                HOR_apertura = entity.HOR_apertura,
                HOR_cierre = entity.HOR_cierre,
                HOR_usuarioCreacion = entity.HOR_usuarioCreacion,
                HOR_fechaCreacion = entity.HOR_fechaCreacion ?? DateTime.UtcNow,
                HOR_usuarioModificacion = entity.HOR_usuarioModificacion,
                HOR_fechaModificacion = entity.HOR_fechaModificacion
            };
        }

        public static HorarioAtencionEntity ToEntity(this HorarioAtencionDataModel model)
        {
            if (model == null) return null!;

            return new HorarioAtencionEntity
            {
                HOR_id = model.HOR_id,
                SUC_id = model.SUC_id,
                HOR_diaSemana = model.HOR_diaSemana,
                HOR_apertura = model.HOR_apertura,
                HOR_cierre = model.HOR_cierre,
                HOR_usuarioCreacion = model.HOR_usuarioCreacion,
                HOR_fechaCreacion = model.HOR_fechaCreacion,
                HOR_usuarioModificacion = model.HOR_usuarioModificacion,
                HOR_fechaModificacion = model.HOR_fechaModificacion
            };
        }
    }
}