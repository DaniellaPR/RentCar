using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class VehiculoDataMapper
    {
        public static VehiculoDataModel ToDataModel(this VehiculoEntity entity)
        {
            if (entity == null)
                return null;

            return new VehiculoDataModel
            {
                VEH_id = entity.VEH_id,
                CAT_id = entity.CAT_id,
                SUC_id = entity.SUC_id,
                VEH_placa = entity.VEH_placa,
                VEH_modelo = entity.VEH_modelo,
                VEH_anio = entity.VEH_anio,
                VEH_color = entity.VEH_color,
                VEH_kilometraje = entity.VEH_kilometraje,
                VEH_estado = entity.VEH_estado,
                VEH_imagenUrl = entity.VEH_imagenUrl,
                VEH_marca = entity.VEH_marca,
                VEH_disponibilidad = entity.VEH_disponibilidad,
                VEH_usuarioCreacion = entity.VEH_usuarioCreacion,
                VEH_fechaCreacion = entity.VEH_fechaCreacion ?? DateTime.UtcNow,
                VEH_usuarioModificacion = entity.VEH_usuarioModificacion,
                VEH_fechaModificacion = entity.VEH_fechaModificacion
            };
        }

        public static VehiculoEntity ToEntity(this VehiculoDataModel model)
        {
            if (model == null)
                return null;

            return new VehiculoEntity
            {
                VEH_id = model.VEH_id,
                CAT_id = model.CAT_id,
                SUC_id = model.SUC_id,
                VEH_placa = model.VEH_placa,
                VEH_modelo = model.VEH_modelo,
                VEH_anio = model.VEH_anio,
                VEH_color = model.VEH_color,
                VEH_kilometraje = model.VEH_kilometraje,
                VEH_estado = model.VEH_estado,
                VEH_imagenUrl = model.VEH_imagenUrl,
                VEH_marca = model.VEH_marca,
                VEH_disponibilidad = model.VEH_disponibilidad,
                VEH_usuarioCreacion = model.VEH_usuarioCreacion,
                VEH_fechaCreacion = model.VEH_fechaCreacion,
                VEH_usuarioModificacion = model.VEH_usuarioModificacion,
                VEH_fechaModificacion = model.VEH_fechaModificacion
            };
        }
    }
}