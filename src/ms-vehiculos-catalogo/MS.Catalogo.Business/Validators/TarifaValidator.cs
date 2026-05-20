using MS.Catalogo.Business.DTOs.Tarifa;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class TarifaValidator
{
    public static void ValidarCreacion(CrearTarifaRequest request)
    {
        var errors = new List<string>();
        if (request.CAT_id == Guid.Empty) errors.Add("La categoría es obligatoria.");
        if (request.TAR_precioDiario <= 0) errors.Add("El precio por día debe ser mayor a 0.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarTarifaRequest request)
    {
        var errors = new List<string>();
        if (request.TAR_id == Guid.Empty) errors.Add("El ID de la tarifa es inválido.");
        if (request.CAT_id == Guid.Empty) errors.Add("La categoría es obligatoria.");
        if (request.TAR_precioDiario <= 0) errors.Add("El precio por día debe ser mayor a 0.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
