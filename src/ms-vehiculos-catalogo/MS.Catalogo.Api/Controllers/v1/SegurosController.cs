using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.Seguro;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class SegurosController : ControllerBase
    {
        private readonly ISeguroService _seguroService;

        public SegurosController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<SeguroResponse>>>> GetAll()
        {
            var result = await _seguroService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<SeguroResponse>>(result, "Seguros obtidos com sucesso."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<SeguroResponse>>> GetById(Guid id)
        {
            var result = await _seguroService.GetByIdAsync(id);
            return Ok(new ApiResponse<SeguroResponse>(result, "Seguro obtido com sucesso."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<SeguroResponse>>> Create([FromBody] CrearSeguroRequest dto)
        {
            var result = await _seguroService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.SEG_id },
                new ApiResponse<SeguroResponse>(result, "Seguro criado com sucesso."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<SeguroResponse>>> Update(Guid id, [FromBody] ActualizarSeguroRequest dto)
        {
            var result = await _seguroService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<SeguroResponse>(result, "Seguro atualizado com sucesso."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _seguroService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
