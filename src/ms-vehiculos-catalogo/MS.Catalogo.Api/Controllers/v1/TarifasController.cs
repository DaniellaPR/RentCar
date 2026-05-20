using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.Tarifa;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifaService _tarifaService;

        public TarifasController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<TarifaResponse>>>> GetAll()
        {
            var result = await _tarifaService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<TarifaResponse>>(result, "Tarifas obtidas com sucesso."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<TarifaResponse>>> GetById(Guid id)
        {
            var result = await _tarifaService.GetByIdAsync(id);
            return Ok(new ApiResponse<TarifaResponse>(result, "Tarifa obtida com sucesso."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TarifaResponse>>> Create([FromBody] CrearTarifaRequest dto)
        {
            var result = await _tarifaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.TAR_id },
                new ApiResponse<TarifaResponse>(result, "Tarifa criada com sucesso."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<TarifaResponse>>> Update(Guid id, [FromBody] ActualizarTarifaRequest dto)
        {
            var result = await _tarifaService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<TarifaResponse>(result, "Tarifa atualizada com sucesso."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _tarifaService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
