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
    public class ReservaDireccionesController : ControllerBase
    {
        private readonly Reserva_DirreccionServices _service;

        public ReservaDireccionesController(Reserva_DirreccionServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaDireccion(Guid id)
        {
            var reservaDireccion = await _service.GetReserva_DirreccionsByIdAsync(id);
            if (reservaDireccion == null)
                return NotFound();

            return Ok(reservaDireccion);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservaDirecciones()
        {
            var reservaDirecciones = await _service.GetAllReserva_DirreccionsAsync();
            return Ok(reservaDirecciones);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservaDireccion([FromBody] Reserva_Dirreccions reservaDireccion)
        {
            if (reservaDireccion == null)
                return BadRequest();

            await _service.CreatePlatillo_ReservaAsync(reservaDireccion);
            return CreatedAtAction(nameof(GetReservaDireccion), new { id = reservaDireccion.id_direccion }, reservaDireccion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservaDireccion(Guid id, [FromBody] Reserva_Dirreccions reservaDireccion)
        {
            if (id != reservaDireccion.id_direccion)
                return BadRequest();

            await _service.UpdateReserva_DirreccionsAsync(reservaDireccion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaDireccion(Guid id)
        {
            await _service.DeleteReserva_DirreccionsAsync(id);
            return NoContent();
        }
    }
}
