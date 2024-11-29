using Cateing.Entity.Models;
using Catering.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly PlatilloService _service;

        public PlatilloController(PlatilloService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatillo(Guid id)
        {
            var result = await _service.GetPlatilloByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlatillo()
        {
            var result = await _service.GetAllPlatilloAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatillo([FromBody] Platillo item)
        {
            await _service.CreatePlatilloAsync(item);
            return CreatedAtAction(nameof(GetPlatillo), new { id = item.id_platillo }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatillo(Guid id, [FromBody] Platillo item)
        {
            if (id != item.id_platillo)
                return BadRequest();

            await _service.UpdatePlatilloAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatillo(Guid id)
        {
            await _service.DeletePlatilloAsync(id);
            return NoContent();
        }
    }
}
