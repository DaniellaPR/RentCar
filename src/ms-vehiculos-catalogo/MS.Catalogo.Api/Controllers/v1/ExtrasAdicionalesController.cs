using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.ExtraAdicional;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class ExtrasAdicionalesController : ControllerBase
    {
        private readonly IExtraAdicionalService _extraAdicionalService;

        public ExtrasAdicionalesController(IExtraAdicionalService extraAdicionalService)
        {
            _extraAdicionalService = extraAdicionalService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ExtraAdicionalResponse>>>> GetAll()
        {
            var result = await _extraAdicionalService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<ExtraAdicionalResponse>>(result, "Extras adicionais obtidos com sucesso."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<ExtraAdicionalResponse>>> GetById(Guid id)
        {
            var result = await _extraAdicionalService.GetByIdAsync(id);
            return Ok(new ApiResponse<ExtraAdicionalResponse>(result, "Extra adicional obtido com sucesso."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ExtraAdicionalResponse>>> Create([FromBody] CrearExtraAdicionalRequest dto)
        {
            var result = await _extraAdicionalService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.EXT_id },
                new ApiResponse<ExtraAdicionalResponse>(result, "Extra adicional criado com sucesso."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<ExtraAdicionalResponse>>> Update(Guid id, [FromBody] ActualizarExtraAdicionalRequest dto)
        {
            var result = await _extraAdicionalService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<ExtraAdicionalResponse>(result, "Extra adicional atualizado com sucesso."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _extraAdicionalService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
