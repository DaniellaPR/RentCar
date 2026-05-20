using MS.Alquiler.DataAccess.Entities;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Mappers
{
    public static class ReservaDataMapper
    {
        public static ReservaDataModel ToDataModel(this ReservaEntity entity)
        {
            if (entity == null) return null!;

            return new ReservaDataModel
            {
                RES_id = entity.RES_id,
                CLI_id = entity.CLI_id,
                VEH_id = entity.VEH_id,
                // FK lógicas cross-MS: la Entity no las persiste,
                // se rellenan desde el request en el BusinessMapper.
                RES_sucursalRetiroId = Guid.Empty,
                RES_sucursalEntregaId = Guid.Empty,
                RES_fechaRetiro = entity.RES_fechaInicio,
                RES_fechaEntrega = entity.RES_fechaFin,
                RES_estado = entity.RES_estado,
                RES_usuarioCreacion = entity.RES_usuarioCreacion,
                RES_fechaCreacion = entity.RES_fechaCreacion ?? DateTime.UtcNow,
                RES_usuarioModificacion = entity.RES_usuarioModificacion,
                RES_fechaModificacion = entity.RES_fechaModificacion
            };
        }

        public static ReservaEntity ToEntity(this ReservaDataModel model)
        {
            if (model == null) return null!;

            return new ReservaEntity
            {
                RES_id = model.RES_id,
                CLI_id = model.CLI_id,
                VEH_id = model.VEH_id,
                RES_fechaReserva = model.RES_fechaCreacion,
                RES_fechaInicio = model.RES_fechaRetiro,
                RES_fechaFin = model.RES_fechaEntrega,
                RES_estado = model.RES_estado,
                RES_usuarioCreacion = model.RES_usuarioCreacion,
                RES_fechaCreacion = model.RES_fechaCreacion,
                RES_usuarioModificacion = model.RES_usuarioModificacion,
                RES_fechaModificacion = model.RES_fechaModificacion
            };
        }
    }
}