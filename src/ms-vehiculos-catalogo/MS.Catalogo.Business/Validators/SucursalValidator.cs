using MS.Catalogo.Business.DTOs.Sucursal;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class SucursalValidator
{
    public static void ValidarCreacion(CrearSucursalRequest request)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(request.SUC_nombre)) errors.Add("El nombre de la sucursal es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.SUC_ciudad)) errors.Add("La ciudad es obligatoria.");
        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarSucursalRequest request)
    {
        var errors = new List<string>();
        if (request.SUC_id == Guid.Empty) errors.Add("El ID de la sucursal es inválido.");
        if (string.IsNullOrWhiteSpace(request.SUC_nombre)) errors.Add("El nombre de la sucursal es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.SUC_ciudad)) errors.Add("La ciudad es obligatoria.");
        if (errors.Any()) throw new ValidationException(errors);
    }
}
