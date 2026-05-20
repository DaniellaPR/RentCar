using MS.Alquiler.DataAccess.Entities;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Mappers
{
    /// <summary>
    /// Mapper entre ReservaDetalleEntity (DataAccess) y ReservaDetalleDataModel (DataManagement).
    /// 
    /// NOTA: La Entity usa DET_ y solo tiene EXT_id (no SEG_id).
    /// El DataModel usa REX_ (según la tabla SQL) y admite SEG_id o EXT_id.
    /// La Entity se actualiza para admitir SEG_id en la Parte 2-extra de Entities,
    /// pero mientras tanto se mapea EXT_id → EXT_id y SEG_id queda null.
    /// </summary>
    public static class ReservaDetalleDataMapper
    {
        public static ReservaDetalleDataModel ToDataModel(this ReservaDetalleEntity entity)
        {
            if (entity == null) return null!;

            return new ReservaDetalleDataModel
            {
                REX_id = entity.DET_id,
                RES_id = entity.RES_id,
                SEG_id = null,             // La Entity actual no tiene SEG_id
                EXT_id = entity.EXT_id,
                REX_cantidad = entity.DET_cantidad,
                REX_usuarioCreacion = entity.DET_usuarioCreacion,
                REX_fechaCreacion = entity.DET_fechaCreacion ?? DateTime.UtcNow,
                REX_usuarioModificacion = entity.DET_usuarioModificacion,
                REX_fechaModificacion = entity.DET_fechaModificacion
            };
        }

        public static ReservaDetalleEntity ToEntity(this ReservaDetalleDataModel model)
        {
            if (model == null) return null!;

            return new ReservaDetalleEntity
            {
                DET_id = model.REX_id,
                RES_id = model.RES_id,
                EXT_id = model.EXT_id ?? Guid.Empty,
                DET_cantidad = model.REX_cantidad,
                DET_subtotal = 0,               // Se calcula en Business
                DET_usuarioCreacion = model.REX_usuarioCreacion,
                DET_fechaCreacion = model.REX_fechaCreacion,
                DET_usuarioModificacion = model.REX_usuarioModificacion,
                DET_fechaModificacion = model.REX_fechaModificacion
            };
        }
    }
}