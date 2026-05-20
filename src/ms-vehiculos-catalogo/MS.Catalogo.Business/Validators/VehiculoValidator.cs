using MS.Catalogo.Business.DTOs.Vehiculo;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class VehiculoValidator
{
    public static void ValidarCreacion(CrearVehiculoRequest request)
    {
        var errors = new List<string>();

        if (request.CAT_id == Guid.Empty) errors.Add("La categoría es obligatoria.");
        if (request.SUC_id == Guid.Empty) errors.Add("La sucursal es obligatoria.");
        if (string.IsNullOrWhiteSpace(request.VEH_marca)) errors.Add("La marca es obligatoria.");
        if (string.IsNullOrWhiteSpace(request.VEH_placa)) errors.Add("La placa es obligatoria.");
        if (request.VEH_anio < 2000 || request.VEH_anio > DateTime.Now.Year + 1) errors.Add("El año del vehículo no es válido.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarVehiculoRequest request)
    {
        var errors = new List<string>();

        if (request.VEH_id == Guid.Empty) errors.Add("El ID del vehículo es inválido.");
        if (request.CAT_id == Guid.Empty) errors.Add("La categoría es obligatoria.");
        if (request.SUC_id == Guid.Empty) errors.Add("La sucursal es obligatoria.");
        if (string.IsNullOrWhiteSpace(request.VEH_marca)) errors.Add("La marca es obligatoria.");
        if (string.IsNullOrWhiteSpace(request.VEH_placa)) errors.Add("La placa es obligatoria.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
