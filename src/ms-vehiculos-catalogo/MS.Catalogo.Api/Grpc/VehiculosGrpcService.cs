using Grpc.Core;
using MS.Catalogo.Api.Grpc;
using MS.Catalogo.Business.Interfaces;

namespace MS.Catalogo.Api.GrpcServices
{
    public class VehiculosGrpcService : VehiculosService.VehiculosServiceBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosGrpcService(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        public override async Task<GetVehiculosResponse> GetVehiculos(GetVehiculosRequest request, ServerCallContext context)
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            var response = new GetVehiculosResponse { Success = true };

            foreach (var vehiculo in vehiculos)
            {
                response.Data.Add(new VehiculoMessage
                {
                    Id = vehiculo.VEH_id.ToString(),
                    Nombre = vehiculo.VEH_modelo,
                    Descripcion = vehiculo.VEH_placa,
                    PrecioPorDia = 0, // Placeholder
                    Moneda = "USD",
                    Categoria = "Estándar", // Placeholder
                    Disponible = vehiculo.VEH_estado == "DISPONIBLE",
                    ImagenUrl = ""
                });
            }

            return response;
        }

        public override async Task<VehiculoMessage> GetVehiculoById(GetVehiculoByIdRequest request, ServerCallContext context)
        {
            if (Guid.TryParse(request.Id, out Guid id))
            {
                var vehiculo = await _vehiculoService.GetByIdAsync(id);
                if (vehiculo != null)
                {
                    return new VehiculoMessage
                    {
                        Id = vehiculo.VEH_id.ToString(),
                        Nombre = vehiculo.VEH_modelo,
                        Descripcion = vehiculo.VEH_placa,
                        PrecioPorDia = 0,
                        Moneda = "USD",
                        Categoria = "Estándar",
                        Disponible = vehiculo.VEH_estado == "DISPONIBLE",
                        ImagenUrl = ""
                    };
                }
            }
            throw new RpcException(new Status(StatusCode.NotFound, "Vehículo no encontrado"));
        }
    }
}
