using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServices _service;

        public ClienteController(ClienteServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var cliente = await _service.GetClienteByIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCliente()
        {
            var clientes = await _service.GetAllClienteAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            await _service.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.id_cuenta }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] Cliente cliente)
        {
            if (id != cliente.id_cuenta)
                return BadRequest();

            await _service.UpdateClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            await _service.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
