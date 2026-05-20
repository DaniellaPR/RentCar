// PARTE 5 — MS.Alquiler.Business/DTOs/Reserva/ActualizarReservaRequest.cs
// CORRECCIÓN: Nombres alineados con ReservaDataModel.

using System.Text.Json.Serialization;

namespace MS.Alquiler.Business.DTOs.Reserva;

public class ActualizarReservaRequest
{
    [JsonIgnore] public Guid RES_id { get; set; }
    public Guid CLI_id { get; set; }
    public Guid VEH_id { get; set; }
    public Guid RES_sucursalRetiroId { get; set; }
    public Guid RES_sucursalEntregaId { get; set; }
    public DateTime RES_fechaRetiro { get; set; }
    public DateTime RES_fechaEntrega { get; set; }
    public string RES_estado { get; set; } = null!;
    public decimal RES_total { get; set; }

    // Auditoría
    [JsonIgnore] public string? RES_usuarioModificacion { get; set; }
}