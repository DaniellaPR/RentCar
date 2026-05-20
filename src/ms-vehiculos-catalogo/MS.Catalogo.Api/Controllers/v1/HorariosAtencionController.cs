using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Catalogo.Api.Models.Common;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.DTOs.HorarioAtencion;

namespace MS.Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class HorariosAtencionController : ControllerBase
    {
        private readonly IHorarioAtencionService _horarioAtencionService;

        public HorariosAtencionController(IHorarioAtencionService horarioAtencionService)
        {
            _horarioAtencionService = horarioAtencionService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<HorarioAtencionResponse>>>> GetAll()
        {
            var result = await _horarioAtencionService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<HorarioAtencionResponse>>(result, "Horários de atendimento obtidos com sucesso."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<HorarioAtencionResponse>>> GetById(Guid id)
        {
            var result = await _horarioAtencionService.GetByIdAsync(id);
            return Ok(new ApiResponse<HorarioAtencionResponse>(result, "Horário de atendimento obtido com sucesso."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<HorarioAtencionResponse>>> Create([FromBody] CrearHorarioAtencionRequest dto)
        {
            var result = await _horarioAtencionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.HOR_id },
                new ApiResponse<HorarioAtencionResponse>(result, "Horário de atendimento criado com sucesso."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<HorarioAtencionResponse>>> Update(Guid id, [FromBody] ActualizarHorarioAtencionRequest dto)
        {
            var result = await _horarioAtencionService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<HorarioAtencionResponse>(result, "Horário de atendimento atualizado com sucesso."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            await _horarioAtencionService.DeleteAsync(id, "admin");
            return NoContent();
        }
    }
}
