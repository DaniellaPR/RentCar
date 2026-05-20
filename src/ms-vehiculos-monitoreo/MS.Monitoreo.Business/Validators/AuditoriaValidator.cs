// PARTE 5 — MS.Monitoreo.Business/Validators/AuditoriaValidator.cs
// CORRECCIÓN: Usa AUD_ prefijos del DTO corregido.

using MS.Monitoreo.Business.DTOs.Auditoria;
using MS.Monitoreo.Business.Exceptions;

namespace MS.Monitoreo.Business.Validators;

public static class AuditoriaValidator
{
    private static readonly string[] OperacionesValidas = { "INSERT", "UPDATE", "DELETE", "SELECT", "LOGIN", "LOGOUT" };

    public static void ValidarCreacion(CrearAuditoriaRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.AUD_nombreTabla))
            errors.Add("El nombre de la tabla es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.AUD_operacion))
            errors.Add("La operación es obligatoria.");
        if (!string.IsNullOrWhiteSpace(request.AUD_operacion)
            && !OperacionesValidas.Contains(request.AUD_operacion.ToUpper()))
            errors.Add($"Operación inválida. Valores permitidos: {string.Join(", ", OperacionesValidas)}.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}