using MS.Catalogo.Business.DTOs.CategoriaVehiculo;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class CategoriaVehiculoBusinessMapper
{
    public static CategoriaVehiculoDataModel ToDataModel(this CrearCategoriaVehiculoRequest request)
    {
        return new CategoriaVehiculoDataModel
        {
            CAT_id = Guid.NewGuid(),
            CAT_nombre = request.CAT_nombre,
            CAT_descripcion = request.CAT_descripcion,
            CAT_costoBase = request.CAT_costoBase,
            CAT_capacidadPasajeros = request.CAT_capacidadPasajeros,
            CAT_capacidadMaletas = request.CAT_capacidadMaletas,
            CAT_tipoTransmision = request.CAT_tipoTransmision,
            CAT_usuarioCreacion = request.CAT_usuarioCreacion,
            CAT_fechaCreacion = DateTime.UtcNow
        };
    }

    public static CategoriaVehiculoResponse ToResponse(this CategoriaVehiculoDataModel model)
    {
        return new CategoriaVehiculoResponse
        {
            CAT_id = model.CAT_id,
            CAT_nombre = model.CAT_nombre,
            CAT_descripcion = model.CAT_descripcion,
            CAT_costoBase = model.CAT_costoBase,
            CAT_capacidadPasajeros = model.CAT_capacidadPasajeros,
            CAT_capacidadMaletas = model.CAT_capacidadMaletas,
            CAT_tipoTransmision = model.CAT_tipoTransmision,
        };
    }
}
