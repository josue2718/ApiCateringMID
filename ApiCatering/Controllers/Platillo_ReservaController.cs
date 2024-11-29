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
    public class PlatilloReservasController : ControllerBase
    {
        private readonly Platillo_ReservaServices _service;

        public PlatilloReservasController(Platillo_ReservaServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatilloReserva(Guid id)
        {
            var platilloReserva = await _service.GetPlatillo_ReservaByIdAsync(id);
            if (platilloReserva == null)
                return NotFound();

            return Ok(platilloReserva);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlatilloReservas()
        {
            var platilloReservas = await _service.GetAllPlatillo_ReservaAsync();
            return Ok(platilloReservas);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatilloReserva([FromBody] Platillo_Reserva platilloReserva)
        {
            if (platilloReserva == null)
                return BadRequest();

            await _service.CreatePlatillo_ReservaAsync(platilloReserva);
            return CreatedAtAction(nameof(GetPlatilloReserva), new { id = platilloReserva.id_platillo }, platilloReserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatilloReserva(Guid id, [FromBody] Platillo_Reserva platilloReserva)
        {
            if (id != platilloReserva.id_platillo)
                return BadRequest();

            await _service.UpdatePlatillo_ReservaAsync(platilloReserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatilloReserva(Guid id)
        {
            await _service.DeletePlatillo_ReservaAsync(id);
            return NoContent();
        }
    }
}
