using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Identidad.Api.Models.Common;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.DTOs.UsuarioApp;

namespace MS.Identidad.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class UsuariosAppController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioService;

        public UsuariosAppController(IUsuarioAppService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UsuarioAppResponse>>>> GetAll()
        {
            var result = await _usuarioService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<UsuarioAppResponse>>(result, "Listado de usuarios de la aplicación obtenido con éxito."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<UsuarioAppResponse>>> GetById(Guid id)
        {
            var result = await _usuarioService.GetByIdAsync(id);
            return Ok(new ApiResponse<UsuarioAppResponse>(result, "Usuario recuperado correctamente."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<UsuarioAppResponse>>> Update(Guid id, [FromBody] ActualizarUsuarioAppRequest dto)
        {
            var result = await _usuarioService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<UsuarioAppResponse>(result, "Perfil de usuario actualizado de forma exitosa."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var result = await _usuarioService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>(result, "Usuario dado de baja del ecosistema de manera correcta."));
        }
    }
}
