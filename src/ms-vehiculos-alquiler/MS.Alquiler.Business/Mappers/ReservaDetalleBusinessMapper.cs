// PARTE 5 — MS.Alquiler.Business/Mappers/ReservaDetalleBusinessMapper.cs
// CORRECCIÓN: ReservaDetalleDataModel usa REX_id, RES_id, SEG_id?, EXT_id?, REX_cantidad.
//             La versión anterior usaba DetId/ResId/ExtId/DetCantidad/DetSubtotal.

using MS.Alquiler.Business.DTOs.ReservaDetalle;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.Business.Mappers;

public static class ReservaDetalleBusinessMapper
{
    public static ReservaDetalleDataModel ToDataModel(this CrearReservaDetalleRequest request)
    {
        return new ReservaDetalleDataModel
        {
            REX_id = Guid.NewGuid(),
            RES_id = request.RES_id,
            SEG_id = request.SEG_id,
            EXT_id = request.EXT_id,
            REX_cantidad = request.REX_cantidad,
            REX_usuarioCreacion = request.REX_usuarioCreacion,
            REX_fechaCreacion = DateTime.UtcNow
        };
    }

    public static ReservaDetalleDataModel ApplyUpdate(this ReservaDetalleDataModel model, ActualizarReservaDetalleRequest request)
    {
        model.RES_id = request.RES_id;
        model.SEG_id = request.SEG_id;
        model.EXT_id = request.EXT_id;
        model.REX_cantidad = request.REX_cantidad;
        model.REX_usuarioModificacion = request.REX_usuarioModificacion;
        model.REX_fechaModificacion = DateTime.UtcNow;
        return model;
    }

    public static ReservaDetalleResponse ToResponse(this ReservaDetalleDataModel model)
    {
        return new ReservaDetalleResponse
        {
            REX_id = model.REX_id,
            RES_id = model.RES_id,
            SEG_id = model.SEG_id,
            EXT_id = model.EXT_id,
            REX_cantidad = model.REX_cantidad
        };
    }
}