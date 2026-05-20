using MS.Catalogo.Business.DTOs.Sucursal;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class SucursalBusinessMapper
{
    public static SucursalDataModel ToDataModel(this CrearSucursalRequest request)
    {
        return new SucursalDataModel
        {
            SUC_id = Guid.NewGuid(),
            SUC_nombre = request.SUC_nombre,
            SUC_ciudad = request.SUC_ciudad,
            SUC_direccion = request.SUC_direccion,
            SUC_coordenadas = request.SUC_coordenadas,
            SUC_usuarioCreacion = request.SUC_usuarioCreacion,
            SUC_fechaCreacion = DateTime.UtcNow
        };
    }

    public static SucursalResponse ToResponse(this SucursalDataModel model)
    {
        return new SucursalResponse
        {
            SUC_id = model.SUC_id,
            SUC_nombre = model.SUC_nombre,
            SUC_ciudad = model.SUC_ciudad,
            SUC_direccion = model.SUC_direccion,
            SUC_coordenadas = model.SUC_coordenadas,
        };
    }
}
