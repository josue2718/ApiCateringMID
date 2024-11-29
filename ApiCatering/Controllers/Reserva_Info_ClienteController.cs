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
    public class ReservaInfoClientesController : ControllerBase
    {
        private readonly Reserva_Info_ClienteServices _service;

        public ReservaInfoClientesController(Reserva_Info_ClienteServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaInfoCliente(Guid id)
        {
            var reservaInfo = await _service.GetReserva_Info_ClienteByIdAsync(id);
            if (reservaInfo == null)
                return NotFound();

            return Ok(reservaInfo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservaInfoClientes()
        {
            var reservaInfos = await _service.GetAllReserva_Info_ClienteAsync();
            return Ok(reservaInfos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservaInfoCliente([FromBody] Reserva_Info_Cliente reservaInfo)
        {
            if (reservaInfo == null)
                return BadRequest();

            await _service.CreateReserva_Info_ClienteAsync(reservaInfo);
            return CreatedAtAction(nameof(GetReservaInfoCliente), new { id = reservaInfo.id_info }, reservaInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservaInfoCliente(Guid id, [FromBody] Reserva_Info_Cliente reservaInfo)
        {
            if (id != reservaInfo.id_info)
                return BadRequest();

            await _service.UpdateReserva_Info_ClienteAsync(reservaInfo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaInfoCliente(Guid id)
        {
            await _service.DeleteReserva_Info_ClienteAsync(id);
            return NoContent();
        }
    }
}
