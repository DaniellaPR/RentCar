using MS.Identidad.Business.DTOs.LicenciaConducir;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.Business.Mappers;

public static class LicenciaConducirBusinessMapper
{
    public static LicenciaConducirDataModel ToDataModel(this CrearLicenciaConducirRequest request)
    {
        return new LicenciaConducirDataModel
        {
            LIC_id = Guid.NewGuid(),
            CLI_id = request.CLI_id,
            LIC_numero = request.LIC_numero,
            LIC_categoria = request.LIC_categoria,
            LIC_vigencia = request.LIC_vigencia
        };
    }

    public static LicenciaConducirResponse ToResponse(this LicenciaConducirDataModel model)
    {
        return new LicenciaConducirResponse
        {
            LIC_id = model.LIC_id,
            CLI_id = model.CLI_id,
            LIC_numero = model.LIC_numero,
            LIC_categoria = model.LIC_categoria,
            LIC_vigencia = model.LIC_vigencia
        };
    }
}
