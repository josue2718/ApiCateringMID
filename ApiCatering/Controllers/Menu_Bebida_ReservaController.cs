using Cateing.Entity.Models;
using Catering.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Menu_Bebida_ReservaController : ControllerBase
    {
        private readonly Menu_Bebida_ReservaService _service;

        public Menu_Bebida_ReservaController(Menu_Bebida_ReservaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu_Bebida_Reserva(Guid id)
        {
            var result = await _service.GetMenu_Bebida_ReservaByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu_Bebida_Reserva()
        {
            var result = await _service.GetAllMenu_Bebida_ReservaAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu_Bebida_Reserva([FromBody] Menu_Bebida_Reserva item)
        {
            await _service.CreateMenu_Bebida_ReservaAsync(item);
            return CreatedAtAction(nameof(GetMenu_Bebida_Reserva), new { id = item.id_menu_bebida }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu_Bebida_Reserva(Guid id, [FromBody] Menu_Bebida_Reserva item)
        {
            if (id != item.id_menu_bebida)
                return BadRequest();

            await _service.UpdateMenu_Bebida_ReservaAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu_Bebida_Reserva(Guid id)
        {
            await _service.DeleteMenu_Bebida_ReservaAsync(id);
            return NoContent();
        }
    }
}
