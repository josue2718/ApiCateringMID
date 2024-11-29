using Catering.Data.Services;
using Cateing.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly CalificacionServices _service;

        public CalificacionController(CalificacionServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificacion(Guid id)
        {
            var calificacion = await _service.GetCalificacionByIdAsync(id);
            if (calificacion == null)
                return NotFound();

            return Ok(calificacion);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCalificacion()
        {
            var calificaciones = await _service.GetAllCalificacionAsync();
            return Ok(calificaciones);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalificacion([FromBody] Calificacion calificacion)
        {
            await _service.CreateCalificacionAsync(calificacion);
            return CreatedAtAction(nameof(GetCalificacion), new { id = calificacion.id_calificacion }, calificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalificacion(Guid id, [FromBody] Calificacion calificacion)
        {
            if (id != calificacion.id_calificacion)
                return BadRequest();

            await _service.UpdateCalificacionAsync(calificacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(Guid id)
        {
            await _service.DeleteCalificacionAsync(id);
            return NoContent();
        }
    }
}
