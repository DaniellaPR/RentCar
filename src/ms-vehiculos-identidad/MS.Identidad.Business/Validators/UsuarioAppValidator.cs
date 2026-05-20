// PARTE 5 — MS.Identidad.Business/Validators/UsuarioAppValidator.cs
// CORRECCIÓN: Usa ROL_id/USU_email/USU_id (sin UsuNombre que no existe en el DataModel).

using MS.Identidad.Business.DTOs.UsuarioApp;
using MS.Identidad.Business.Exceptions;

namespace MS.Identidad.Business.Validators;

public static class UsuarioAppValidator
{
    public static void ValidarCreacion(CrearUsuarioAppRequest request)
    {
        var errors = new List<string>();

        if (request.ROL_id == Guid.Empty)
            errors.Add("El rol es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.USU_email) || !request.USU_email.Contains('@'))
            errors.Add("Debe enviar un correo electrónico válido.");
        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            errors.Add("La contraseña debe tener al menos 6 caracteres.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarUsuarioAppRequest request)
    {
        var errors = new List<string>();

        if (request.USU_id == Guid.Empty)
            errors.Add("ID de usuario inválido.");
        if (request.ROL_id == Guid.Empty)
            errors.Add("El rol es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.USU_email) || !request.USU_email.Contains('@'))
            errors.Add("Debe enviar un correo electrónico válido.");

        var estadosValidos = new[] { "ACTIVO", "INACTIVO" };
        if (!string.IsNullOrWhiteSpace(request.USU_estado) && !estadosValidos.Contains(request.USU_estado))
            errors.Add("Estado inválido. Valores permitidos: ACTIVO, INACTIVO.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
