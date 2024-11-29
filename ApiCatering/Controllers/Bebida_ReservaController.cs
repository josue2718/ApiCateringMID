using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaReservaController : ControllerBase
    {
        private readonly Bebida_ReservaServices _service;

        public BebidaReservaController(Bebida_ReservaServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBebidaReserva(Guid id)
        {
            var bebidaReserva = await _service.GetBebida_ReservaByIdAsync(id);
            if (bebidaReserva == null)
                return NotFound();

            return Ok(bebidaReserva);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBebidaReserva()
        {
            var bebidasReserva = await _service.GetAllBebida_ReservaAsync();
            return Ok(bebidasReserva);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBebidaReserva([FromBody] Bebida_Reserva bebidaReserva)
        {
            await _service.CreateBebida_ReservaAsync(bebidaReserva);
            return CreatedAtAction(nameof(GetBebidaReserva), new { id = bebidaReserva.id_bebida }, bebidaReserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBebidaReserva(Guid id, [FromBody] Bebida_Reserva bebidaReserva)
        {
            if (id != bebidaReserva.id_bebida)
                return BadRequest();

            await _service.UpdateBebida_ReservaAsync(bebidaReserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBebidaReserva(Guid id)
        {
            await _service.DeleteBebida_ReservaAsync(id);
            return NoContent();
        }
    }
}
