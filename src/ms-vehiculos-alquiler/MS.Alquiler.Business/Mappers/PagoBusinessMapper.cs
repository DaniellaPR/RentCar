// PARTE 5 — MS.Alquiler.Business/Mappers/PagoBusinessMapper.cs
// CORRECCIÓN: PagoDataModel usa PAG_id, RES_id, PAG_fechaPago, PAG_monto, PAG_metodo, PAG_estado.
//             La versión anterior usaba PagId/ResId/PagFecha/PagMonto/PagMetodo/PagEstado.

using MS.Alquiler.Business.DTOs.Pago;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.Business.Mappers;

public static class PagoBusinessMapper
{
    public static PagoDataModel ToDataModel(this CrearPagoRequest request)
    {
        return new PagoDataModel
        {
            PAG_id = Guid.NewGuid(),
            RES_id = request.RES_id,
            PAG_fechaPago = DateTime.UtcNow,
            PAG_monto = request.PAG_monto,
            PAG_metodo = request.PAG_metodo,
            PAG_estado = "COMPLETADO"   // al registrarse se asume pago exitoso
        };
    }

    public static PagoDataModel ApplyUpdate(this PagoDataModel model, ActualizarPagoRequest request)
    {
        model.PAG_monto = request.PAG_monto;
        model.PAG_metodo = request.PAG_metodo;
        model.PAG_estado = request.PAG_estado;
        return model;
    }

    public static PagoResponse ToResponse(this PagoDataModel model)
    {
        return new PagoResponse
        {
            PAG_id = model.PAG_id,
            RES_id = model.RES_id,
            PAG_fechaPago = model.PAG_fechaPago,
            PAG_monto = model.PAG_monto,
            PAG_metodo = model.PAG_metodo,
            PAG_estado = model.PAG_estado
        };
    }
}