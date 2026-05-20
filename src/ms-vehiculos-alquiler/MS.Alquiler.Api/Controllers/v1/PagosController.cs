// MS.Alquiler.Api/Controllers/v1/PagosController.cs
// FIX:
//   1. result.Id → result.PAG_id  (PagoResponse tiene PAG_id, no Id)
//   2. GetAll() no existe en IPagoService; se cambia a GetByReserva
//   3. DeleteAsync no existe en IPagoService; se elimina el endpoint Delete
//   4. Versionado: añadido [ApiVersion] y ruta correcta con v{version:apiVersion}

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Alquiler.Api.Models.Common;
using MS.Alquiler.Business.DTOs.Pago;
using MS.Alquiler.Business.Interfaces;

namespace MS.Alquiler.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paula-pozo/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagosController(IPagoService pagoService)
            => _pagoService = pagoService;

        // ── GET /pagos/reserva/{reservaId} ────────────────────────────────────
        [HttpGet("reserva/{reservaId:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<IEnumerable<PagoResponse>>>> GetByReserva(
            Guid reservaId)
        {
            var result = await _pagoService.GetAllByReservaIdAsync(reservaId);
            return Ok(new ApiResponse<IEnumerable<PagoResponse>>(
                result, "Pagos de la reserva obtenidos correctamente."));
        }

        // ── GET /pagos/{id} ───────────────────────────────────────────────────
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<PagoResponse>>> GetById(Guid id)
        {
            var result = await _pagoService.GetByIdAsync(id);
            return Ok(new ApiResponse<PagoResponse>(
                result, "Información de pago obtenida correctamente."));
        }

        // ── POST /pagos ───────────────────────────────────────────────────────
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse<PagoResponse>>> Create(
            [FromBody] CrearPagoRequest dto)
        {
            var result = await _pagoService.CreateAsync(dto);
            // FIX: era result.Id → correcto es result.PAG_id
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.PAG_id },
                new ApiResponse<PagoResponse>(result, "Pago registrado exitosamente."));
        }

        // ── PUT /pagos/{id} ───────────────────────────────────────────────────
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<PagoResponse>>> Update(
            Guid id, [FromBody] ActualizarPagoRequest dto)
        {
            var result = await _pagoService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<PagoResponse>(
                result, "Estado del pago actualizado exitosamente."));
        }
    }
}
