// PARTE 5 — MS.Alquiler.Business/Validators/ReservaDetalleValidator.cs
// CORRECCIÓN: Nombres alineados con nuevos DTOs. Valida la regla SEG_id XOR EXT_id.

using MS.Alquiler.Business.DTOs.ReservaDetalle;
using MS.Alquiler.Business.Exceptions;

namespace MS.Alquiler.Business.Validators;

public static class ReservaDetalleValidator
{
    public static void ValidarCreacion(CrearReservaDetalleRequest request)
    {
        var errors = new List<string>();

        if (request.RES_id == Guid.Empty)
            errors.Add("El ID de la reserva es obligatorio.");

        // CHECK constraint de la BD: SEG_id o EXT_id, nunca ambos null
        if (request.SEG_id == null && request.EXT_id == null)
            errors.Add("El detalle debe tener un seguro (SEG_id) o un extra adicional (EXT_id).");
        if (request.SEG_id != null && request.EXT_id != null)
            errors.Add("El detalle no puede tener seguro y extra adicional al mismo tiempo.");

        if (request.REX_cantidad <= 0)
            errors.Add("La cantidad debe ser mayor a 0.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarReservaDetalleRequest request)
    {
        var errors = new List<string>();

        if (request.REX_id == Guid.Empty)
            errors.Add("El ID del detalle es inválido.");
        if (request.RES_id == Guid.Empty)
            errors.Add("El ID de la reserva es obligatorio.");
        if (request.SEG_id == null && request.EXT_id == null)
            errors.Add("El detalle debe tener un seguro (SEG_id) o un extra adicional (EXT_id).");
        if (request.SEG_id != null && request.EXT_id != null)
            errors.Add("El detalle no puede tener seguro y extra adicional al mismo tiempo.");
        if (request.REX_cantidad <= 0)
            errors.Add("La cantidad debe ser mayor a 0.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}