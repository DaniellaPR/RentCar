using MS.Identidad.Business.DTOs.Cliente;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.Business.Mappers;

public static class ClienteBusinessMapper
{
    public static ClienteDataModel ToDataModel(this CrearClienteRequest request)
    {
        return new ClienteDataModel
        {
            CLI_id = Guid.NewGuid(),
            CLI_nombres = request.CLI_nombres,
            CLI_apellidos = request.CLI_apellidos,
            CLI_cedula = request.CLI_cedula,
            CLI_telefono = request.CLI_telefono,
            CLI_usuarioCreacion = request.CLI_usuarioCreacion,

        };
    }

    public static ClienteDataModel ApplyUpdate(this ClienteDataModel model, ActualizarClienteRequest request)
    {
        model.CLI_nombres = request.CLI_nombres;
        model.CLI_apellidos = request.CLI_apellidos;
        model.CLI_cedula = request.CLI_cedula;
        model.CLI_telefono = request.CLI_telefono;
        model.CLI_usuarioModificacion = request.CLI_usuarioModificacion;
        model.CLI_fechaModificacion = DateTime.UtcNow;
        return model;
    }

    public static ClienteResponse ToResponse(this ClienteDataModel model)
    {
        return new ClienteResponse
        {
            CLI_id = model.CLI_id,
            CLI_nombres = model.CLI_nombres,
            CLI_apellidos = model.CLI_apellidos,
            CLI_cedula = model.CLI_cedula,
            CLI_telefono = model.CLI_telefono,

        };
    }
}
