using MS.Catalogo.Business.DTOs.Mantenimiento;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class MantenimientoValidator
{
    public static void ValidarCreacion(CrearMantenimientoRequest request)
    {
        var errors = new List<string>();
        if (request.VEH_id == Guid.Empty) errors.Add("El vehículo es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.MAN_descripcion)) errors.Add("La descripción es obligatoria.");
        if (request.MAN_costo < 0) errors.Add("El costo no puede ser negativo.");
        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarMantenimientoRequest request)
    {
        var errors = new List<string>();
        if (request.MAN_id == Guid.Empty) errors.Add("El ID es inválido.");
        if (request.VEH_id == Guid.Empty) errors.Add("El vehículo es obligatorio.");
        if (string.IsNullOrWhiteSpace(request.MAN_descripcion)) errors.Add("La descripción es obligatoria.");
        if (errors.Any()) throw new ValidationException(errors);
    }
}
