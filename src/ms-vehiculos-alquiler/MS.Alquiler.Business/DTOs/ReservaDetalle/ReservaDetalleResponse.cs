// PARTE 5 — MS.Alquiler.Business/DTOs/ReservaDetalle/ReservaDetalleResponse.cs
// CORRECCIÓN: ReservaDetalleDataModel usa REX_id, RES_id, SEG_id?, EXT_id?, REX_cantidad.
//             No tiene DetSubtotal en el DataModel — se elimina para no generar null ref.

namespace MS.Alquiler.Business.DTOs.ReservaDetalle;

public class ReservaDetalleResponse
{
    public Guid REX_id { get; set; }
    public Guid RES_id { get; set; }
    /// <summary>Id del seguro asociado (null si es un extra).</summary>
    public Guid? SEG_id { get; set; }
    /// <summary>Id del extra adicional (null si es un seguro).</summary>
    public Guid? EXT_id { get; set; }
    public int REX_cantidad { get; set; }
}