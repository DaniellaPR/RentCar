using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Mappers
{
    public static class LicenciaConducirDataMapper
    {
        public static LicenciaConducirDataModel ToDataModel(this LicenciaConducirEntity entity)
        {
            if (entity == null) return null!;

            return new LicenciaConducirDataModel
            {
                LIC_id = entity.LIC_id,
                CLI_id = entity.CLI_id,
                LIC_numero = entity.LIC_numero,
                LIC_categoria = entity.LIC_categoria,
                LIC_vigencia = entity.LIC_vigencia,
                LIC_usuarioCreacion = entity.LIC_usuarioCreacion,
                LIC_fechaCreacion = entity.LIC_fechaCreacion ?? DateTime.UtcNow,
                LIC_usuarioModificacion = entity.LIC_usuarioModificacion,
                LIC_fechaModificacion = entity.LIC_fechaModificacion
            };
        }

        public static LicenciaConducirEntity ToEntity(this LicenciaConducirDataModel model)
        {
            if (model == null) return null!;

            return new LicenciaConducirEntity
            {
                LIC_id = model.LIC_id,
                CLI_id = model.CLI_id,
                LIC_numero = model.LIC_numero,
                LIC_categoria = model.LIC_categoria,
                LIC_vigencia = model.LIC_vigencia,
                LIC_usuarioCreacion = model.LIC_usuarioCreacion,
                LIC_fechaCreacion = model.LIC_fechaCreacion,
                LIC_usuarioModificacion = model.LIC_usuarioModificacion,
                LIC_fechaModificacion = model.LIC_fechaModificacion
            };
        }
    }
}