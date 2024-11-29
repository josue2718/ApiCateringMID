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
    public class ReservasController : ControllerBase
    {
        private readonly ReservasService _service;

        public ReservasController(ReservasService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(Guid id)
        {
            var reserva = await _service.GetReservaByIdAsync(id);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservas()
        {
            var reservas = await _service.GetAllReservaAsync();
            return Ok(reservas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] Reserva reserva)
        {
            if (reserva == null)
                return BadRequest();

            await _service.CreateReservaAsync(reserva);
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.id_reserva }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(Guid id, [FromBody] Reserva reserva)
        {
            if (id != reserva.id_reserva)
                return BadRequest();

            await _service.UpdateReservaAsync(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(Guid id)
        {
            await _service.DeleteReservaAsync(id);
            return NoContent();
        }
    }
}
