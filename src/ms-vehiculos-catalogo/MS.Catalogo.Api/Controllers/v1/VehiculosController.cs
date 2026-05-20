// MS.Catalogo.Api/Controllers/v1/VehiculosController.cs
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.DTOs.Vehiculo;
using MS.Catalogo.Business.Interfaces;

namespace MS.Catalogo.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paula-pozo/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
            => _vehiculoService = vehiculoService;

        // ─── GET /vehiculos ──────────────────────────────────────────────────────
        // Contrato Booking: GET /vehiculos?page=&pageSize=&search=&categoria=&disponible=
        // Angular: lista completa para marketplace
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<IEnumerable<VehiculoBookingDto>>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? search = null,
            [FromQuery] string? categoria = null,
            [FromQuery] bool? disponible = null)
        {
            var todos = await _vehiculoService.GetAllAsync();

            // Filtros en memoria (simple para Reto 2 — en Reto 3 se mueven a DataService)
            var query = todos.AsEnumerable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(v =>
                    v.VEH_modelo.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    v.VEH_marca.Contains(search, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(v =>
                    v.CategoriaNombre.Contains(categoria, StringComparison.OrdinalIgnoreCase));

            if (disponible.HasValue)
                query = query.Where(v => v.VEH_disponibilidad == disponible.Value);

            var paginado = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(v => v.ToBookingDto())
                .ToList();

            return Ok(new ApiResponse<IEnumerable<VehiculoBookingDto>>(
                paginado,
                $"Vehículos obtenidos. Página {page}, total en página: {paginado.Count}."));
        }

        // ─── GET /vehiculos/{id} ────────────────────────────────────────────────
        // Contrato Booking: GET /vehiculos/{id}
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<VehiculoBookingDto>>> GetById(Guid id)
        {
            var result = await _vehiculoService.GetByIdAsync(id);
            return Ok(new ApiResponse<VehiculoBookingDto>(result.ToBookingDto(), "Vehículo obtenido correctamente."));
        }

        // ─── GET /vehiculos/{id}/disponibilidad ─────────────────────────────────
        // Contrato Booking: GET /vehiculos/{id}/disponibilidad?fechaInicio=&fechaFin=
        // Este es el endpoint más importante para la integración con el Booking.
        [HttpGet("{id:guid}/disponibilidad")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<DisponibilidadVehiculoDto>>> GetDisponibilidad(
            Guid id,
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            if (fechaInicio >= fechaFin)
                return BadRequest(new ApiResponse<DisponibilidadVehiculoDto>(
                    null!, "fechaFin debe ser posterior a fechaInicio."));

            if (fechaInicio.Date < DateTime.UtcNow.Date)
                return BadRequest(new ApiResponse<DisponibilidadVehiculoDto>(
                    null!, "fechaInicio no puede ser una fecha pasada."));

            var disponible = await _vehiculoService.GetDisponibilidadAsync(id, fechaInicio, fechaFin);

            var dto = new DisponibilidadVehiculoDto
            {
                Disponible = disponible,
                Mensaje    = disponible
                    ? "El vehículo está disponible en las fechas solicitadas."
                    : "El vehículo no está disponible. Existe una reserva activa en ese rango."
            };

            return Ok(new ApiResponse<DisponibilidadVehiculoDto>(dto, dto.Mensaje));
        }

        // ─── POST /vehiculos (admin) ─────────────────────────────────────────────
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse<VehiculoResponse>>> Create([FromBody] CrearVehiculoRequest dto)
        {
            var result = await _vehiculoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.VEH_id },
                new ApiResponse<VehiculoResponse>(result, "Vehículo creado exitosamente."));
        }

        // ─── PUT /vehiculos/{id} (admin) ─────────────────────────────────────────
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<VehiculoResponse>>> Update(
            Guid id, [FromBody] ActualizarVehiculoRequest dto)
        {
            var result = await _vehiculoService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<VehiculoResponse>(result, "Vehículo actualizado exitosamente."));
        }

        // ─── DELETE /vehiculos/{id} (admin) ──────────────────────────────────────
        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _vehiculoService.DeleteAsync(id, User.Identity?.Name ?? "admin");
            return NoContent();
        }
    }
}
