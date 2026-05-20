using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class MantenimientoDataMapper
    {
        public static MantenimientoDataModel ToDataModel(this MantenimientoEntity entity)
        {
            if (entity == null) return null!;

            return new MantenimientoDataModel
            {
                MAN_id = entity.MAN_id,
                VEH_id = entity.VEH_id,
                MAN_fecha = entity.MAN_fecha,
                MAN_descripcion = entity.MAN_descripcion,
                MAN_costo = entity.MAN_costo,
                MAN_usuarioCreacion = entity.MAN_usuarioCreacion,
                MAN_fechaCreacion = entity.MAN_fechaCreacion ?? DateTime.UtcNow,
                MAN_usuarioModificacion = entity.MAN_usuarioModificacion,
                MAN_fechaModificacion = entity.MAN_fechaModificacion
            };
        }

        public static MantenimientoEntity ToEntity(this MantenimientoDataModel model)
        {
            if (model == null) return null!;

            return new MantenimientoEntity
            {
                MAN_id = model.MAN_id,
                VEH_id = model.VEH_id,
                MAN_fecha = model.MAN_fecha,
                MAN_descripcion = model.MAN_descripcion,
                MAN_costo = model.MAN_costo,
                MAN_usuarioCreacion = model.MAN_usuarioCreacion,
                MAN_fechaCreacion = model.MAN_fechaCreacion,
                MAN_usuarioModificacion = model.MAN_usuarioModificacion,
                MAN_fechaModificacion = model.MAN_fechaModificacion
            };
        }
    }
}