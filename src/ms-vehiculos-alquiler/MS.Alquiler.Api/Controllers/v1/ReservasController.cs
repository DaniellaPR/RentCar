// MS.Alquiler.Api/Controllers/v1/ReservasController.cs
// FIX principal:
//   - ActualizarEstadoRequest movido a archivo propio (abajo) para evitar ambigüedad
//   - _reservaService.DeleteAsync(id) existe en IReservaService
//   - allowed puede ser null: se protege con Array.Empty
//   - Ruta: api/v{version:apiVersion}/paula-pozo/reservas
//   - Booking contract: GET /reservas/{id}, POST /reservas, PATCH /reservas/{id}

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Alquiler.Api.Models.Common;
using MS.Alquiler.Business.DTOs.Reserva;
using MS.Alquiler.Business.Interfaces;

namespace MS.Alquiler.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paula-pozo/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservasController(IReservaService reservaService)
            => _reservaService = reservaService;

        // ── GET /reservas ─────────────────────────────────────────────────────
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReservaResponse>>>> GetAll()
        {
            var result = await _reservaService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<ReservaResponse>>(
                result, "Reservas obtenidas correctamente."));
        }

        // ── GET /reservas/cliente/{clienteId} ─────────────────────────────────
        [HttpGet("cliente/{clienteId:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReservaResponse>>>> GetByCliente(
            Guid clienteId)
        {
            var result = await _reservaService.GetByClienteAsync(clienteId);
            return Ok(new ApiResponse<IEnumerable<ReservaResponse>>(
                result, "Reservas del cliente obtenidas correctamente."));
        }

        // ── GET /reservas/{id}  — Contrato Booking ────────────────────────────
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<ReservaResponse>>> GetById(Guid id)
        {
            var result = await _reservaService.GetByIdAsync(id);
            return Ok(new ApiResponse<ReservaResponse>(
                result, "Reserva obtenida correctamente."));
        }

        // ── POST /reservas  — Contrato Booking ───────────────────────────────
        [HttpPost]
        [AllowAnonymous]   // Booking llama sin token; Angular lleva JWT del cliente
        public async Task<ActionResult<ApiResponse<ReservaResponse>>> Create(
            [FromBody] CrearReservaRequest dto)
        {
            var result = await _reservaService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.RES_id },
                new ApiResponse<ReservaResponse>(result, "Reserva creada exitosamente."));
        }

        // ── PATCH /reservas/{id}  — Contrato Booking: cambio de estado ────────
        [HttpPatch("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<ReservaResponse>>> UpdateEstado(
            Guid id,
            [FromBody] ActualizarEstadoReservaRequest dto)
        {
            // Máquina de estados válida
            var transitions = new Dictionary<string, string[]>
            {
                ["PENDIENTE"] = ["CONFIRMADA", "CANCELADA"],
                ["CONFIRMADA"] = ["ACTIVA", "CANCELADA"],
                ["ACTIVA"] = ["FINALIZADA"]
            };

            var reserva = await _reservaService.GetByIdAsync(id);
            var estadoActual = reserva.RES_estado;

            if (!transitions.TryGetValue(estadoActual, out var allowed)
                || !allowed.Contains(dto.Estado))
            {
                var permitidos = allowed is not null
                    ? string.Join(", ", allowed)
                    : "ninguno";
                return UnprocessableEntity(new ApiResponse<ReservaResponse>(
                    $"Transición inválida: {estadoActual} → {dto.Estado}. Permitidos: {permitidos}."));
            }

            var request = new ActualizarReservaRequest { RES_estado = dto.Estado };
            var result = await _reservaService.UpdateAsync(id, request);
            return Ok(new ApiResponse<ReservaResponse>(
                result, $"Estado actualizado a {dto.Estado}."));
        }

        // ── PUT /reservas/{id} — admin: actualización completa ────────────────
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<ReservaResponse>>> Update(
            Guid id, [FromBody] ActualizarReservaRequest dto)
        {
            var result = await _reservaService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<ReservaResponse>(
                result, "Reserva actualizada exitosamente."));
        }

        // ── POST /reservas/{id}/cancelar — business cancel ────────────────────
        [HttpPost("{id:guid}/cancelar")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<string>>> Cancelar(Guid id)
        {
            await _reservaService.CancelarReservaAsync(id);
            return Ok(new ApiResponse<string>("CANCELADA", "Reserva cancelada correctamente."));
        }

        // ── DELETE /reservas/{id} — admin ─────────────────────────────────────
        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var result = await _reservaService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>(result, "Reserva eliminada."));
        }


        [HttpGet("debug-token")]
        [Authorize]
        public IActionResult DebugToken()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

            return Ok(new
            {
                Header = authHeader,
                Usuario = User.Identity?.Name,
                Claims = User.Claims.Select(c => new
                {
                    c.Type,
                    c.Value
                })
            });
        }


    }

    // DTO inline del PATCH — nombre único para evitar conflicto con otros controllers
    public class ActualizarEstadoReservaRequest
    {
        public string Estado { get; set; } = string.Empty;
    }
}
