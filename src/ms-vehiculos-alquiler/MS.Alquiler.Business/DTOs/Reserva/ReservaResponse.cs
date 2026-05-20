// PARTE 5 — MS.Alquiler.Business/DTOs/Reserva/ReservaResponse.cs
// CORRECCIÓN CRÍTICA: ReservaDataModel usa RES_id, CLI_id, VEH_id, RES_fechaRetiro,
//                    RES_fechaEntrega, RES_estado. El mapper debe usar esos nombres.
//                    Se añaden RES_sucursalRetiroId, RES_sucursalEntregaId y RES_total
//                    que están en el DataModel.

namespace MS.Alquiler.Business.DTOs.Reserva;

public class ReservaResponse
{
    public Guid RES_id { get; set; }
    public Guid CLI_id { get; set; }
    public Guid VEH_id { get; set; }
    public Guid RES_sucursalRetiroId { get; set; }
    public Guid RES_sucursalEntregaId { get; set; }
    public DateTime RES_fechaRetiro { get; set; }
    public DateTime RES_fechaEntrega { get; set; }
    public string RES_estado { get; set; } = "PENDIENTE";
    public decimal RES_total { get; set; }
    public DateTime RES_fechaCreacion { get; set; }
}