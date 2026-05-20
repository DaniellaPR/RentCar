// PARTE 5 — MS.Alquiler.Business/Validators/ReservaValidator.cs
// CORRECCIÓN: Nombres de campo alineados con los nuevos DTOs (RES_/CLI_/VEH_ prefijos).

using MS.Alquiler.Business.DTOs.Reserva;
using MS.Alquiler.Business.Exceptions;

namespace MS.Alquiler.Business.Validators;

public static class ReservaValidator
{
    public static void ValidarCreacion(CrearReservaRequest request)
    {
        var errors = new List<string>();

        if (request.CLI_id == Guid.Empty)
            errors.Add("El ID del cliente es obligatorio.");
        if (request.VEH_id == Guid.Empty)
            errors.Add("El ID del vehículo es obligatorio.");
        if (request.RES_sucursalRetiroId == Guid.Empty)
            errors.Add("La sucursal de retiro es obligatoria.");
        if (request.RES_sucursalEntregaId == Guid.Empty)
            errors.Add("La sucursal de entrega es obligatoria.");
        if (request.RES_fechaRetiro < DateTime.UtcNow.Date)
            errors.Add("La fecha de retiro no puede ser en el pasado.");
        if (request.RES_fechaEntrega <= request.RES_fechaRetiro)
            errors.Add("La fecha de entrega debe ser posterior a la fecha de retiro.");
        if (request.RES_total < 0)
            errors.Add("El total no puede ser negativo.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarReservaRequest request)
    {
        var errors = new List<string>();

        if (request.RES_id == Guid.Empty)
            errors.Add("El ID de la reserva es inválido.");
        if (request.CLI_id == Guid.Empty)
            errors.Add("El ID del cliente es obligatorio.");
        if (request.VEH_id == Guid.Empty)
            errors.Add("El ID del vehículo es obligatorio.");
        if (request.RES_fechaEntrega <= request.RES_fechaRetiro)
            errors.Add("La fecha de entrega debe ser posterior a la fecha de retiro.");
        if (string.IsNullOrWhiteSpace(request.RES_estado))
            errors.Add("El estado de la reserva es obligatorio.");

        var estadosValidos = new[] { "PENDIENTE", "CONFIRMADA", "CANCELADA", "COMPLETADA" };
        if (!string.IsNullOrWhiteSpace(request.RES_estado) && !estadosValidos.Contains(request.RES_estado))
            errors.Add($"Estado inválido. Valores permitidos: {string.Join(", ", estadosValidos)}.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}