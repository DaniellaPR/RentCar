using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.CategoriaVehiculo;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class CategoriasVehiculoController : ControllerBase
    {
        private readonly ICategoriaVehiculoService _categoriaService;

        public CategoriasVehiculoController(ICategoriaVehiculoService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CategoriaVehiculoResponse>>>> GetAll()
        {
            var result = await _categoriaService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<CategoriaVehiculoResponse>>(result, "Categorías obtenidas correctamente."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<CategoriaVehiculoResponse>>> GetById(Guid id)
        {
            var result = await _categoriaService.GetByIdAsync(id);
            return Ok(new ApiResponse<CategoriaVehiculoResponse>(result, "Categoría obtenida correctamente."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CategoriaVehiculoResponse>>> Create([FromBody] CrearCategoriaVehiculoRequest dto)
        {
            var result = await _categoriaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.CAT_id },
                new ApiResponse<CategoriaVehiculoResponse>(result, "Categoría creada exitosamente."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<CategoriaVehiculoResponse>>> Update(Guid id, [FromBody] ActualizarCategoriaVehiculoRequest dto)
        {
            var result = await _categoriaService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<CategoriaVehiculoResponse>(result, "Categoría actualizada exitosamente."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _categoriaService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
