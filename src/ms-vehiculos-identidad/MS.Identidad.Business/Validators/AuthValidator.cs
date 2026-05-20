using MS.Identidad.Business.DTOs.Auth;
using MS.Identidad.Business.Exceptions;

namespace MS.Identidad.Business.Validators;

public static class AuthValidator
{
    public static void ValidarLogin(LoginRequest request)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(request.Correo)) errors.Add("El correo es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.Password)) errors.Add("La contraseña es obligatoria.");
        if (errors.Any()) throw new ValidationException(errors);
    }
}
