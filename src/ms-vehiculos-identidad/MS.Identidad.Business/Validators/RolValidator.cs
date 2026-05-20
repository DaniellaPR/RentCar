using MS.Identidad.Business.DTOs.Rol;
using MS.Identidad.Business.Exceptions;

namespace MS.Identidad.Business.Validators;

public static class RolValidator
{
    public static void ValidarCreacion(CrearRolRequest request)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(request.ROL_nombre)) errors.Add("El nombre del rol es obligatorio.");
        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarRolRequest request)
    {
        var errors = new List<string>();
        if (request.ROL_id == Guid.Empty) errors.Add("El ID del rol es inválido.");
        if (string.IsNullOrWhiteSpace(request.ROL_nombre)) errors.Add("El nombre del rol es obligatorio.");
        if (errors.Any()) throw new ValidationException(errors);
    }
}
