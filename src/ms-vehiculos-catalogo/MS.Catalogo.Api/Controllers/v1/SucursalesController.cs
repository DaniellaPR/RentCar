using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.Sucursal;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public SucursalesController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<SucursalResponse>>>> GetAll()
        {
            var result = await _sucursalService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<SucursalResponse>>(result, "Sucursales obtenidas correctamente."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<SucursalResponse>>> GetById(Guid id)
        {
            var result = await _sucursalService.GetByIdAsync(id);
            return Ok(new ApiResponse<SucursalResponse>(result, "Sucursal obtenida correctamente."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<SucursalResponse>>> Create([FromBody] CrearSucursalRequest dto)
        {
            var result = await _sucursalService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.SUC_id },
                new ApiResponse<SucursalResponse>(result, "Sucursal creada exitosamente."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<SucursalResponse>>> Update(Guid id, [FromBody] ActualizarSucursalRequest dto)
        {
            var result = await _sucursalService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<SucursalResponse>(result, "Sucursal actualizada exitosamente."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _sucursalService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
