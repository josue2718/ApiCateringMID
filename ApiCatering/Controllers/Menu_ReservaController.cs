using Cateing.Entity.Models;
using Catering.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Menu_ReservaController : ControllerBase
    {
        private readonly Menu_ReservaService _service;

        public Menu_ReservaController(Menu_ReservaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu_Reserva(Guid id)
        {
            var result = await _service.GetMenu_ReservaByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu_Reserva()
        {
            var result = await _service.GetAllMenu_ReservaAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu_Reserva([FromBody] Menu_Reserva item)
        {
            await _service.CreateMenu_ReservaAsync(item);
            return CreatedAtAction(nameof(GetMenu_Reserva), new { id = item.id_cliente }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu_Reserva(Guid id, [FromBody] Menu_Reserva item)
        {
            if (id != item.id_menu)
                return BadRequest();

            await _service.UpdateMenu_ReservaAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu_Reserva(Guid id)
        {
            await _service.DeleteMenu_ReservaAsync(id);
            return NoContent();
        }
    }
}
