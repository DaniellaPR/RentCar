// MS.Alquiler.Api/Controllers/v1/ReservaDetallesController.cs
// FIX:
//   1. result.Id → result.REX_id
//   2. GetAll() no existe → se cambia a GetByReserva
//   3. [ApiVersion] + ruta versionada correcta

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Alquiler.Api.Models.Common;
using MS.Alquiler.Business.DTOs.ReservaDetalle;
using MS.Alquiler.Business.Interfaces;

namespace MS.Alquiler.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paula-pozo/[controller]")]
    public class ReservaDetallesController : ControllerBase
    {
        private readonly IReservaDetalleService _detalleService;

        public ReservaDetallesController(IReservaDetalleService detalleService)
            => _detalleService = detalleService;

        // ── GET /reserva-detalles/reserva/{reservaId} ─────────────────────────
        [HttpGet("reserva/{reservaId:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReservaDetalleResponse>>>> GetByReserva(
            Guid reservaId)
        {
            var result = await _detalleService.GetByReservaAsync(reservaId);
            return Ok(new ApiResponse<IEnumerable<ReservaDetalleResponse>>(
                result, "Detalles de la reserva obtenidos correctamente."));
        }

        // ── GET /reserva-detalles/{id} ────────────────────────────────────────
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<ReservaDetalleResponse>>> GetById(Guid id)
        {
            var result = await _detalleService.GetByIdAsync(id);
            return Ok(new ApiResponse<ReservaDetalleResponse>(
                result, "Detalle de reserva obtenido correctamente."));
        }

        // ── POST /reserva-detalles ────────────────────────────────────────────
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse<ReservaDetalleResponse>>> Create(
            [FromBody] CrearReservaDetalleRequest dto)
        {
            var result = await _detalleService.CreateAsync(dto);
            // FIX: era result.Id → correcto es result.REX_id
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.REX_id },
                new ApiResponse<ReservaDetalleResponse>(result, "Detalle de reserva creado."));
        }

        // ── PUT /reserva-detalles/{id} ────────────────────────────────────────
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<ReservaDetalleResponse>>> Update(
            Guid id, [FromBody] ActualizarReservaDetalleRequest dto)
        {
            var result = await _detalleService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<ReservaDetalleResponse>(
                result, "Detalle de reserva actualizado."));
        }

        // ── DELETE /reserva-detalles/{id} ─────────────────────────────────────
        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _detalleService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>(true, "Detalle de reserva eliminado."));
        }
    }
}
