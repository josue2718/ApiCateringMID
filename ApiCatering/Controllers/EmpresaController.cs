using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaServices _service;

        public EmpresaController(EmpresaServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresa(Guid id)
        {
            var empresa = await _service.GetEmpresaByIdAsync(id);
            if (empresa == null)
                return NotFound();

            return Ok(empresa);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmpresas()
        {
            var empresas = await _service.GetAllEmpresaAsync();
            return Ok(empresas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpresa([FromBody] Empresa empresa)
        {
            if (empresa == null)
                return BadRequest();

            await _service.CreateEmpresaAsync(empresa);
            return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.id_empresa }, empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpresa(Guid id, [FromBody] Empresa empresa)
        {
            if (id != empresa.id_empresa)
                return BadRequest();

            await _service.UpdateEmpresaAsync(empresa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(Guid id)
        {
            await _service.DeleteEmpresaAsync(id);
            return NoContent();
        }
    }
}
