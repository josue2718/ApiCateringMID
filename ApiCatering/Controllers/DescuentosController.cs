using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentosController : ControllerBase
    {
        private readonly DescuentosService _service;

        public DescuentosController(DescuentosService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDescuento(Guid id)
        {
            var descuento = await _service.GetDescuentosByIdAsync(id);
            if (descuento == null)
                return NotFound();

            return Ok(descuento);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDescuentos()
        {
            var descuentos = await _service.GetAllDescuentosAsync();
            return Ok(descuentos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDescuento([FromBody] Descuentos descuento)
        {
            await _service.CreateDescuentosAsync(descuento);
            return CreatedAtAction(nameof(GetDescuento), new { id = descuento.id_descuento }, descuento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDescuento(Guid id, [FromBody] Descuentos descuento)
        {
            if (id != descuento.id_descuento)
                return BadRequest();

            await _service.UpdateDescuentosAsync(descuento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescuento(Guid id)
        {
            await _service.DeleteDescuentosAsync(id);
            return NoContent();
        }
    }
}
