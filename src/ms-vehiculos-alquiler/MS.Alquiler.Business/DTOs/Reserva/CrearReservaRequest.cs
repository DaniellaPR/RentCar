// PARTE 5 — MS.Alquiler.Business/DTOs/Reserva/CrearReservaRequest.cs
// CORRECCIÓN: Nombres alineados con ReservaDataModel.
//             Se añaden RES_sucursalRetiroId y RES_sucursalEntregaId (FK lógicas cross-MS).
//             El campo RES_total lo calcula el backend, pero se recibe para casos donde
//             el frontend lo precalcula.

using System.Text.Json.Serialization;

namespace MS.Alquiler.Business.DTOs.Reserva;

public class CrearReservaRequest
{
    public Guid CLI_id { get; set; }
    public Guid VEH_id { get; set; }
    /// <summary>Sucursal donde se retira el vehículo (FK lógica a ms-catalogo).</summary>
    public Guid RES_sucursalRetiroId { get; set; }
    /// <summary>Sucursal donde se devuelve el vehículo (FK lógica a ms-catalogo).</summary>
    public Guid RES_sucursalEntregaId { get; set; }
    public DateTime RES_fechaRetiro { get; set; }
    public DateTime RES_fechaEntrega { get; set; }
    /// <summary>Total calculado en el frontend o fijado en 0 para calcular en backend.</summary>
    public decimal RES_total { get; set; }

    // Auditoría
    [JsonIgnore] public string? RES_usuarioCreacion { get; set; }
}