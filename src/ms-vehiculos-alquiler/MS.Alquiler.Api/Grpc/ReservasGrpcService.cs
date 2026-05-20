// MS.Alquiler.Api/Grpc/ReservasGrpcService.cs
// FIX: response.Total no existe → correcto es response.RES_total (ReservaResponse)
//      El cast (double) se aplica sobre RES_total que es decimal.

using Grpc.Core;
using MS.Alquiler.Api.Grpc;
using MS.Alquiler.Business.Interfaces;

namespace MS.Alquiler.Api.GrpcServices
{
    public class ReservasGrpcService : ReservasService.ReservasServiceBase
    {
        private readonly IReservaService _reservaService;

        public ReservasGrpcService(IReservaService reservaService)
            => _reservaService = reservaService;

        // ── rpc CrearReserva ──────────────────────────────────────────────────
        public override async Task<ReservaResponseMsg> CrearReserva(
            CrearReservaRequestMsg request, ServerCallContext context)
        {
            try
            {
                var response = await _reservaService.CreateAsync(
                    new Business.DTOs.Reserva.CrearReservaRequest
                    {
                        VEH_id = Guid.Parse(request.VehiculoId),
                        CLI_id = Guid.Parse(request.ClienteId),
                        RES_fechaRetiro = DateTime.Parse(request.FechaInicio),
                        RES_fechaEntrega = DateTime.Parse(request.FechaFin)
                    });

                return new ReservaResponseMsg
                {
                    Success = true,
                    Id = response.RES_id.ToString(),
                    Estado = response.RES_estado,
                    // FIX: era response.Total → correcto es response.RES_total
                    Total = (double)response.RES_total
                };
            }
            catch (Exception ex)
            {
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument, ex.Message));
            }
        }

        // ── rpc ActualizarEstado ──────────────────────────────────────────────
        public override async Task<SuccessResponseMsg> ActualizarEstado(
            ActualizarEstadoRequestMsg request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.Id, out Guid id))
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument, "ID de reserva inválido."));

            await _reservaService.UpdateAsync(
                id,
                new Business.DTOs.Reserva.ActualizarReservaRequest
                {
                    RES_estado = request.Estado
                });

            return new SuccessResponseMsg { Success = true, Message = "Estado actualizado." };
        }

        // ── rpc ConsultarDisponibilidad ───────────────────────────────────────
        public override async Task<DisponibilidadResponse> ConsultarDisponibilidad(
            ConsultarDisponibilidadRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.Id, out Guid id))
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument, "ID de vehículo inválido."));

            var disponible = await _reservaService.GetDisponibilidadAsync(
                id,
                DateTime.Parse(request.FechaInicio),
                DateTime.Parse(request.FechaFin));

            return new DisponibilidadResponse
            {
                Success = true,
                Disponible = disponible,
                Mensaje = disponible
                    ? "Vehículo disponible en las fechas indicadas."
                    : "Vehículo no disponible en las fechas indicadas."
            };
        }
    }
}
