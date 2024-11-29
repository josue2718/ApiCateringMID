using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaPropietarioController : ControllerBase
    {
        private readonly Cuenta_PropietarioServices _service;

        public CuentaPropietarioController(Cuenta_PropietarioServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuentaPropietario(Guid id)
        {
            var cuentaPropietario = await _service.GetCuenta_PropietarioByIdAsync(id);
            if (cuentaPropietario == null)
                return NotFound();

            return Ok(cuentaPropietario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCuentaPropietario()
        {
            var cuentasPropietario = await _service.GetAllCuenta_PropietarioAsync();
            return Ok(cuentasPropietario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuentaPropietario([FromBody] Cuenta_Propietario cuentaPropietario)
        {
            await _service.CreateCuenta_PropietarioAsync(cuentaPropietario);
            return CreatedAtAction(nameof(GetCuentaPropietario), new { id = cuentaPropietario.id_cuenta_propietario }, cuentaPropietario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCuentaPropietario(Guid id, [FromBody] Cuenta_Propietario cuentaPropietario)
        {
            if (id != cuentaPropietario.id_cuenta_propietario)
                return BadRequest();

            await _service.UpdateCuenta_PropietarioAsync(cuentaPropietario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentaPropietario(Guid id)
        {
            await _service.DeleteCuenta_PropietarioAsync(id);
            return NoContent();
        }
    }
}
