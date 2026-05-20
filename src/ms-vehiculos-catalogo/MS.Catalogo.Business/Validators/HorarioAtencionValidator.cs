using MS.Catalogo.Business.DTOs.HorarioAtencion;
using MS.Catalogo.Business.Exceptions;

namespace MS.Catalogo.Business.Validators;

public static class HorarioAtencionValidator
{
    public static void ValidarCreacion(CrearHorarioAtencionRequest request)
    {
        var errors = new List<string>();
        if (request.SUC_id == Guid.Empty) errors.Add("La sucursal es obligatoria.");
        if (request.HOR_diaSemana < 1 || request.HOR_diaSemana > 7) errors.Add("El día de la semana debe ser entre 1 y 7.");
        if (request.HOR_horaApertura >= request.HOR_horaCierre) errors.Add("La hora de apertura debe ser antes de la hora de cierre.");

        if (errors.Any()) throw new ValidationException(errors);
    }

    public static void ValidarActualizacion(ActualizarHorarioAtencionRequest request)
    {
        var errors = new List<string>();
        if (request.HOR_id == Guid.Empty) errors.Add("El ID del horario es inválido.");
        if (request.SUC_id == Guid.Empty) errors.Add("La sucursal es obligatoria.");
        if (request.HOR_diaSemana < 1 || request.HOR_diaSemana > 7) errors.Add("El día de la semana debe ser entre 1 y 7.");
        if (request.HOR_horaApertura >= request.HOR_horaCierre) errors.Add("La hora de apertura debe ser antes de la hora de cierre.");

        if (errors.Any()) throw new ValidationException(errors);
    }
}
