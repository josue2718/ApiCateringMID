using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly BebidaServices _service;

        public BebidaController(BebidaServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBebida(Guid id)
        {
            var bebida = await _service.GetBebidaByIdAsync(id);
            if (bebida == null)
                return NotFound();

            return Ok(bebida);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBebida()
        {
            var bebidas = await _service.GetAllBebidaAsync();
            return Ok(bebidas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBebida([FromBody] Bebida bebida)
        {
            await _service.CreateBebidaAsync(bebida);
            return CreatedAtAction(nameof(GetBebida), new { id = bebida.id_bebida }, bebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBebida(Guid id, [FromBody] Bebida bebida)
        {
            if (id != bebida.id_bebida)
                return BadRequest();

            await _service.UpdateBebidaAsync(bebida);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBebida(Guid id)
        {
            await _service.DeleteBebidaAsync(id);
            return NoContent();
        }
    }
}
