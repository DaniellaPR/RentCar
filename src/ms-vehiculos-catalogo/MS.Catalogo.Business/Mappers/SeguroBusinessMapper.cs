using MS.Catalogo.Business.DTOs.Seguro;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class SeguroBusinessMapper
{
    public static SeguroDataModel ToDataModel(this CrearSeguroRequest request)
    {
        return new SeguroDataModel
        {
            SEG_id = Guid.NewGuid(),
            SEG_nombre = request.SEG_nombre,
            SEG_cobertura = request.SEG_cobertura,   // correcto: es SEG_cobertura, no descripcion
            SEG_costoDiario = request.SEG_costoDiario,
            SEG_usuarioCreacion = request.SEG_usuarioCreacion,
            SEG_fechaCreacion = DateTime.UtcNow
        };
    }

    public static SeguroResponse ToResponse(this SeguroDataModel model)
    {
        return new SeguroResponse
        {
            SEG_id = model.SEG_id,
            SEG_nombre = model.SEG_nombre,
            SEG_cobertura = model.SEG_cobertura,
            SEG_costoDiario = model.SEG_costoDiario,
        };
    }
}
