using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Monitoreo.Api.Models.Common;
using MS.Monitoreo.Business.Interfaces;
using MS.Monitoreo.Business.DTOs.Auditoria;

namespace MS.Monitoreo.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class AuditoriasController : ControllerBase
    {
        private readonly IAuditoriaService _auditoriaService;

        public AuditoriasController(IAuditoriaService auditoriaService)
        {
            _auditoriaService = auditoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<AuditoriaResponse>>>> GetAll()
        {
            var result = await _auditoriaService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<AuditoriaResponse>>(result, "Registros de auditoría obtenidos correctamente."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<AuditoriaResponse>>> GetById(Guid id)
        {
            var result = await _auditoriaService.GetByIdAsync(id);
            return Ok(new ApiResponse<AuditoriaResponse>(result, "Registro de auditoría encontrado con éxito."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<AuditoriaResponse>>> Create([FromBody] CrearAuditoriaRequest dto)
        {
            var result = await _auditoriaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.AUD_id },
                new ApiResponse<AuditoriaResponse>(result, "Registro de auditoría grabado con éxito."));
        }

        // Nota: Por regla general de negocio, los registros de auditoría no deberían actualizarse ni eliminarse.
        // Sin embargo, si necesitas los endpoints de Update y Delete para pruebas académicas,
        // puedes implementarlos siguiendo la misma firma que en los otros controladores.
    }
}
