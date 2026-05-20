using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Identidad.Api.Models.Common;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.DTOs.Rol;

namespace MS.Identidad.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RolResponse>>>> GetAll()
        {
            var result = await _rolService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<RolResponse>>(result, "Roles del sistema listados con éxito."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<RolResponse>>> GetById(Guid id)
        {
            var result = await _rolService.GetByIdAsync(id);
            return Ok(new ApiResponse<RolResponse>(result, "Rol recuperado de manera correcta."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<RolResponse>>> Create([FromBody] CrearRolRequest dto)
        {
            var result = await _rolService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.ROL_id },
                new ApiResponse<RolResponse>(result, "Rol administrativo creado exitosamente."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<RolResponse>>> Update(Guid id, [FromBody] ActualizarRolRequest dto)
        {
            var result = await _rolService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<RolResponse>(result, "Rol modificado con éxito."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var result = await _rolService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>(result, "Rol eliminado lógicamente del sistema."));
        }
    }
}
