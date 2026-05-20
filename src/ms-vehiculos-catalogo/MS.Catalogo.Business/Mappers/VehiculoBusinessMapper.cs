using MS.Catalogo.Business.DTOs.Vehiculo;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class VehiculoBusinessMapper
{
    public static VehiculoDataModel ToDataModel(this CrearVehiculoRequest request)
    {
        return new VehiculoDataModel
        {
            VEH_id = Guid.NewGuid(),
            CAT_id = request.CAT_id,
            SUC_id = request.SUC_id,
            VEH_placa = request.VEH_placa,
            VEH_modelo = request.VEH_modelo,
            VEH_anio = request.VEH_anio,
            VEH_color = request.VEH_color,
            VEH_kilometraje = request.VEH_kilometraje,
            VEH_imagenUrl = request.VEH_imagenUrl,
            VEH_usuarioCreacion = request.VEH_usuarioCreacion,
            VEH_fechaCreacion = DateTime.UtcNow
        };
    }

    public static VehiculoResponse ToResponse(this VehiculoDataModel model,
        string categoriaNombre = "", string sucursalNombre = "")
    {
        return new VehiculoResponse
        {
            VEH_id = model.VEH_id,
            CAT_id = model.CAT_id,
            CategoriaNombre = categoriaNombre,
            SUC_id = model.SUC_id,
            SucursalNombre = sucursalNombre,
            VEH_placa = model.VEH_placa,
            VEH_modelo = model.VEH_modelo,
            VEH_anio = model.VEH_anio,
            VEH_color = model.VEH_color,
            VEH_kilometraje = model.VEH_kilometraje,
            VEH_imagenUrl = model.VEH_imagenUrl,
        };
    }
}
