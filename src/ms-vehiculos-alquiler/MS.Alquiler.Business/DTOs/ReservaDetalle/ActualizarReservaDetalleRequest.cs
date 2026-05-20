// PARTE 5 — MS.Alquiler.Business/DTOs/ReservaDetalle/ActualizarReservaDetalleRequest.cs

using System.Text.Json.Serialization;

namespace MS.Alquiler.Business.DTOs.ReservaDetalle;

public class ActualizarReservaDetalleRequest
{
    [JsonIgnore] public Guid REX_id { get; set; }
    public Guid RES_id { get; set; }
    public Guid? SEG_id { get; set; }
    public Guid? EXT_id { get; set; }
    public int REX_cantidad { get; set; } = 1;

    // Auditoría
    [JsonIgnore] public string? REX_usuarioModificacion { get; set; }
}