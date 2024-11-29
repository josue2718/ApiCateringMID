using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaClienteController : ControllerBase
    {
        private readonly Cuenta_ClienteServices _service;

        public CuentaClienteController(Cuenta_ClienteServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuentaCliente(Guid id)
        {
            var cuentaCliente = await _service.GetCuenta_ClienteByIdAsync(id);
            if (cuentaCliente == null)
                return NotFound();

            return Ok(cuentaCliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCuentaCliente()
        {
            var cuentasCliente = await _service.GetAllCuenta_ClienteAsync();
            return Ok(cuentasCliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuentaCliente([FromBody] Cuenta_Cliente cuentaCliente)
        {
            await _service.CreateCuenta_ClienteAsync(cuentaCliente);
            return CreatedAtAction(nameof(GetCuentaCliente), new { id = cuentaCliente.id_cuenta_cliente }, cuentaCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCuentaCliente(Guid id, [FromBody] Cuenta_Cliente cuentaCliente)
        {
            if (id != cuentaCliente.id_cuenta_cliente)
                return BadRequest();

            await _service.UpdateCuenta_ClienteAsync(cuentaCliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentaCliente(Guid id)
        {
            await _service.DeleteCuenta_ClienteAsync(id);
            return NoContent();
        }
    }
}
