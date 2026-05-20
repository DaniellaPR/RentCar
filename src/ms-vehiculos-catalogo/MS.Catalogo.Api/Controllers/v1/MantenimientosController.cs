using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.Mantenimiento;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class MantenimientosController : ControllerBase
    {
        private readonly IMantenimientoService _mantenimientoService;

        public MantenimientosController(IMantenimientoService mantenimientoService)
        {
            _mantenimientoService = mantenimientoService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<MantenimientoResponse>>>> GetAll()
        {
            var result = await _mantenimientoService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<MantenimientoResponse>>(result, "Mantenimientos obtidos com sucesso."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<MantenimientoResponse>>> GetById(Guid id)
        {
            var result = await _mantenimientoService.GetByIdAsync(id);
            return Ok(new ApiResponse<MantenimientoResponse>(result, "Mantenimiento obtido com sucesso."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<MantenimientoResponse>>> Create([FromBody] CrearMantenimientoRequest dto)
        {
            var result = await _mantenimientoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.MAN_id },
                new ApiResponse<MantenimientoResponse>(result, "Mantenimiento criado com sucesso."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<MantenimientoResponse>>> Update(Guid id, [FromBody] ActualizarMantenimientoRequest dto)
        {
            var result = await _mantenimientoService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<MantenimientoResponse>(result, "Mantenimiento atualizado com sucesso."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _mantenimientoService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
