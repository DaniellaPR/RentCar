using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Mappers
{
    public static class ClienteDataMapper
    {
        public static ClienteDataModel ToDataModel(this ClienteEntity entity)
        {
            if (entity == null) return null!;

            return new ClienteDataModel
            {
                CLI_id = entity.CLI_id,
                CLI_nombres = entity.CLI_nombres,
                CLI_apellidos = entity.CLI_apellidos,
                CLI_cedula = entity.CLI_cedula,
                CLI_telefono = entity.CLI_telefono,
                CLI_usuarioCreacion = entity.CLI_usuarioCreacion,
                CLI_fechaCreacion = entity.CLI_fechaCreacion ?? DateTime.UtcNow,
                CLI_usuarioModificacion = entity.CLI_usuarioModificacion,
                CLI_fechaModificacion = entity.CLI_fechaModificacion
            };
        }

        public static ClienteEntity ToEntity(this ClienteDataModel model)
        {
            if (model == null) return null!;

            return new ClienteEntity
            {
                CLI_id = model.CLI_id,
                CLI_nombres = model.CLI_nombres,
                CLI_apellidos = model.CLI_apellidos,
                CLI_cedula = model.CLI_cedula,
                CLI_telefono = model.CLI_telefono,
                CLI_usuarioCreacion = model.CLI_usuarioCreacion,
                CLI_fechaCreacion = model.CLI_fechaCreacion,
                CLI_usuarioModificacion = model.CLI_usuarioModificacion,
                CLI_fechaModificacion = model.CLI_fechaModificacion
            };
        }
    }
}