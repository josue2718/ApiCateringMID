using Cateing.Entity.Models;
using Catering.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Propietario_EmpresaController : ControllerBase
    {
        private readonly Propietario_EmpresaService _service;

        public Propietario_EmpresaController(Propietario_EmpresaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropietario_Empresa(Guid id)
        {
            var result = await _service.GetPropietario_EmpresaByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPropietario_Empresa()
        {
            var result = await _service.GetAllPropietario_EmpresaAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePropietario_Empresa([FromBody] Propietario_Empresa item)
        {
            await _service.CreatePropietario_EmpresaAsync(item);
            return CreatedAtAction(nameof(GetPropietario_Empresa), new { id = item.id_propietario }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePropietario_Empresa(Guid id, [FromBody] Propietario_Empresa item)
        {
            if (id != item.id_propietario)
                return BadRequest();

            await _service.UpdatePropietario_EmpresaAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropietario_Empresa(Guid id)
        {
            await _service.DeletePropietario_EmpresaAsync(id);
            return NoContent();
        }
    }
}
