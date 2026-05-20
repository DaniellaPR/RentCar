using MS.Identidad.Business.DTOs.LicenciaConducir;
using MS.Identidad.Business.Exceptions;

namespace MS.Identidad.Business.Validators;

public static class LicenciaConducirValidator
{
    public static void ValidarCreacion(CrearLicenciaConducirRequest request)
    {
        var errors = new List<string>();
        if (request.CLI_id == Guid.Empty) errors.Add("El cliente es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.LIC_numero)) errors.Add("El número de licencia es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.LIC_categoria)) errors.Add("La categoría es obligatoria.");
        if (request.LIC_vigencia < DateTime.UtcNow.Date) errors.Add("La licencia está caducada o la fecha es inválida.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarLicenciaConducirRequest request)
    {
        var errors = new List<string>();
        if (request.LIC_id == Guid.Empty) errors.Add("El ID de la licencia es inválido.");
        if (request.CLI_id == Guid.Empty) errors.Add("El cliente es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.LIC_numero)) errors.Add("El número de licencia es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.LIC_categoria)) errors.Add("La categoría es obligatoria.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
