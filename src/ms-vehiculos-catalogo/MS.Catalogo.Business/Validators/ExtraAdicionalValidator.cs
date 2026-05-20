using MS.Catalogo.Business.DTOs.ExtraAdicional;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class ExtraAdicionalValidator
{
    public static void ValidarCreacion(CrearExtraAdicionalRequest request)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(request.EXT_nombre)) errors.Add("El nombre del extra es obligatorio.");
        if (request.EXT_costo < 0) errors.Add("El costo diario no puede ser negativo.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarExtraAdicionalRequest request)
    {
        var errors = new List<string>();
        if (request.EXT_id == Guid.Empty) errors.Add("El ID del extra es inválido.");
        if (string.IsNullOrWhiteSpace(request.EXT_nombre)) errors.Add("El nombre del extra es obligatorio.");
        if (request.EXT_costo < 0) errors.Add("El costo diario no puede ser negativo.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
