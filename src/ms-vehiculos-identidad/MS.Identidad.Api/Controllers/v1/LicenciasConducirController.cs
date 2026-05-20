using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Identidad.Api.Models.Common;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.DTOs.LicenciaConducir;

namespace MS.Identidad.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/paula-pozo/[controller]")]
    public class LicenciasConducirController : ControllerBase
    {
        private readonly ILicenciaConducirService _licenciaService;

        public LicenciasConducirController(ILicenciaConducirService licenciaService)
        {
            _licenciaService = licenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<LicenciaConducirResponse>>>> GetAll()
        {
            var result = await _licenciaService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<LicenciaConducirResponse>>(result, "Registros de licencias de conducir cargados correctamente."));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<LicenciaConducirResponse>>> GetById(Guid id)
        {
            var result = await _licenciaService.GetByIdAsync(id);
            return Ok(new ApiResponse<LicenciaConducirResponse>(result, "Licencia de conducir localizada con éxito."));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<LicenciaConducirResponse>>> Create([FromBody] CrearLicenciaConducirRequest dto)
        {
            var result = await _licenciaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.LIC_id },
                new ApiResponse<LicenciaConducirResponse>(result, "Acreditación de licencia guardada exitosamente."));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<LicenciaConducirResponse>>> Update(Guid id, [FromBody] ActualizarLicenciaConducirRequest dto)
        {
            var result = await _licenciaService.UpdateAsync(id, dto);
            return Ok(new ApiResponse<LicenciaConducirResponse>(result, "Licencia vehicular modificada correctamente."));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var result = await _licenciaService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>(result, "Registro de licencia vehicular removido con éxito."));
        }
    }
}
