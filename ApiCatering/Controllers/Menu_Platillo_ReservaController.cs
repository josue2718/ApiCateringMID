using Cateing.Entity.Models;
using Catering.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Menu_Platillo_ReservaController : ControllerBase
    {
        private readonly Menu_Platillo_ReservaService _service;

        public Menu_Platillo_ReservaController(Menu_Platillo_ReservaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu_Platillo_Reserva(Guid id)
        {
            var result = await _service.GetMenu_Platillo_ReservaByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu_Platillo_Reserva()
        {
            var result = await _service.GetAllMenu_Platillo_ReservaAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu_Platillo_Reserva([FromBody] Menu_Platillo_Reserva item)
        {
            await _service.CreateMenu_Platillo_ReservaAsync(item);
            return CreatedAtAction(nameof(GetMenu_Platillo_Reserva), new { id = item.id_menu_platillo }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu_Platillo_Reserva(Guid id, [FromBody] Menu_Platillo_Reserva item)
        {
            if (id != item.id_menu_platillo)
                return BadRequest();

            await _service.UpdateMenu_Platillo_ReservaAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu_Platillo_Reserva(Guid id)
        {
            await _service.DeleteMenu_Platillo_ReservaAsync(id);
            return NoContent();
        }
    }
}
