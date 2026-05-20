using MS.Catalogo.Business.DTOs.CategoriaVehiculo;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class CategoriaVehiculoValidator
{
    public static void ValidarCreacion(CrearCategoriaVehiculoRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.CAT_nombre))
            errors.Add("El nombre de la categoría es obligatorio.");

        if (request.CAT_costoBase <= 0)
            errors.Add("El costo base debe ser mayor a 0.");

        if (errors.Any())
            throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarCategoriaVehiculoRequest request)
    {
        var errors = new List<string>();

        if (request.CAT_id == Guid.Empty)
            errors.Add("El ID de la categoría es inválido.");

        if (string.IsNullOrWhiteSpace(request.CAT_nombre))
            errors.Add("El nombre de la categoría es obligatorio.");

        if (request.CAT_costoBase <= 0)
            errors.Add("El costo base debe ser mayor a 0.");

        if (errors.Any())
            throw new ValidationException(errors);
    }
}
