// PARTE 5 — MS.Alquiler.Business/DTOs/ReservaDetalle/CrearReservaDetalleRequest.cs
// CORRECCIÓN: Alineado con ReservaDetalleDataModel. El detalle puede ser SEG_id O EXT_id
//             (nunca ambos null — regla de negocio validada en el validator).

using System.Text.Json.Serialization;

namespace MS.Alquiler.Business.DTOs.ReservaDetalle;

public class CrearReservaDetalleRequest
{
    public Guid RES_id { get; set; }
    /// <summary>Asigna si el ítem es un seguro. Mutua exclusión con EXT_id.</summary>
    public Guid? SEG_id { get; set; }
    /// <summary>Asigna si el ítem es un extra adicional. Mutua exclusión con SEG_id.</summary>
    public Guid? EXT_id { get; set; }
    public int REX_cantidad { get; set; } = 1;

    // Auditoría
    [JsonIgnore] public string? REX_usuarioCreacion { get; set; }
}