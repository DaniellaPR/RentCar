// PARTE 5 — MS.Alquiler.Business/Validators/PagoValidator.cs
// CORRECCIÓN: Nombres de campo alineados con los nuevos DTOs (PAG_/RES_ prefijos).

using MS.Alquiler.Business.DTOs.Pago;
using MS.Alquiler.Business.Exceptions;

namespace MS.Alquiler.Business.Validators;

public static class PagoValidator
{
    public static void ValidarCreacion(CrearPagoRequest request)
    {
        var errors = new List<string>();

        if (request.RES_id == Guid.Empty)
            errors.Add("El ID de la reserva es obligatorio.");
        if (request.PAG_monto <= 0)
            errors.Add("El monto del pago debe ser mayor a 0.");
        if (string.IsNullOrWhiteSpace(request.PAG_metodo))
            errors.Add("El método de pago es obligatorio.");

        var metodosValidos = new[] { "TARJETA", "PAYPAL", "TRANSFERENCIA", "EFECTIVO" };
        if (!string.IsNullOrWhiteSpace(request.PAG_metodo) && !metodosValidos.Contains(request.PAG_metodo.ToUpper()))
            errors.Add($"Método de pago inválido. Valores permitidos: {string.Join(", ", metodosValidos)}.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarPagoRequest request)
    {
        var errors = new List<string>();

        if (request.PAG_id == Guid.Empty)
            errors.Add("El ID del pago es inválido.");
        if (request.PAG_monto <= 0)
            errors.Add("El monto del pago debe ser mayor a 0.");
        if (string.IsNullOrWhiteSpace(request.PAG_metodo))
            errors.Add("El método de pago es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.PAG_estado))
            errors.Add("El estado del pago es obligatorio.");

        var estadosValidos = new[] { "PENDIENTE", "COMPLETADO", "RECHAZADO", "REEMBOLSADO" };
        if (!string.IsNullOrWhiteSpace(request.PAG_estado) && !estadosValidos.Contains(request.PAG_estado.ToUpper()))
            errors.Add($"Estado inválido. Valores permitidos: {string.Join(", ", estadosValidos)}.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}