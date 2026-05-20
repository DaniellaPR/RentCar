using MS.Catalogo.Business.DTOs.Seguro;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class SeguroValidator
{
    public static void ValidarCreacion(CrearSeguroRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.SEG_nombre))
            errors.Add("El nombre del seguro es obligatorio.");

        if (request.SEG_costoDiario < 0)
            errors.Add("El costo diario del seguro no puede ser negativo.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarSeguroRequest request)
    {
        var errors = new List<string>();

        if (request.SEG_id == Guid.Empty)
            errors.Add("El ID del seguro es inválido.");

        if (string.IsNullOrWhiteSpace(request.SEG_nombre))
            errors.Add("El nombre del seguro es obligatorio.");

        if (request.SEG_costoDiario < 0)
            errors.Add("El costo diario del seguro no puede ser negativo.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
