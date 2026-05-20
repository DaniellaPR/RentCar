// PARTE 5 — MS.Identidad.Business/Validators/ClienteValidator.cs
// CORRECCIÓN: Usa CLI_nombres/CLI_apellidos/CLI_cedula/CLI_id (nuevos nombres del DTO).

using MS.Identidad.Business.DTOs.Cliente;
using MS.Identidad.Business.Exceptions;

namespace MS.Identidad.Business.Validators;

public static class ClienteValidator
{
    public static void ValidarCreacion(CrearClienteRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.CLI_nombres))
            errors.Add("Los nombres son obligatorios.");
        if (string.IsNullOrWhiteSpace(request.CLI_apellidos))
            errors.Add("Los apellidos son obligatorios.");
        if (string.IsNullOrWhiteSpace(request.CLI_cedula))
            errors.Add("La cédula es obligatoria.");
        if (request.CLI_cedula?.Length < 8)
            errors.Add("La cédula debe tener al menos 8 caracteres.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarClienteRequest request)
    {
        var errors = new List<string>();

        if (request.CLI_id == Guid.Empty)
            errors.Add("El ID del cliente es inválido.");
        if (string.IsNullOrWhiteSpace(request.CLI_nombres))
            errors.Add("Los nombres son obligatorios.");
        if (string.IsNullOrWhiteSpace(request.CLI_apellidos))
            errors.Add("Los apellidos son obligatorios.");
        if (string.IsNullOrWhiteSpace(request.CLI_cedula))
            errors.Add("La cédula es obligatoria.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
