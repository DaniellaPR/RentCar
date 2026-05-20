using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Identidad.Api.Models.Common;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.DTOs.Cliente;

namespace MS.Identidad.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ClienteResponse>>>> GetAll()
        {
            var result = await _clienteService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<ClienteResponse>>(result, "Clientes comerciales obtenidos correctamente."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<ClienteResponse>>> GetById(Guid id)
        {
            var result = await _clienteService.GetByIdAsync(id);
            return Ok(new ApiResponse<ClienteResponse>(result, "Ficha del cliente obtenida correctamente."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ClienteResponse>>> Create([FromBody] CrearClienteRequest dto)
        {
            var result = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.CLI_id },
                new ApiResponse<ClienteResponse>(result, "Registro de cliente creado con éxito."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<ClienteResponse>>> Update(Guid id, [FromBody] ActualizarClienteRequest dto)
        {
            var result = await _clienteService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<ClienteResponse>(result, "Información del cliente actualizada exitosamente."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var result = await _clienteService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>(result, "Cliente eliminado físicamente/lógicamente con éxito."));
        }
    }
}
