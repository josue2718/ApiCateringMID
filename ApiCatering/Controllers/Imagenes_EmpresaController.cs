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
    public class ImagenesEmpresaController : ControllerBase
    {
        private readonly Imagenes_EmpresaServices _service;

        public ImagenesEmpresaController(Imagenes_EmpresaServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImagenesEmpresa(Guid id)
        {
            var imagen = await _service.GetImagenes_EmpresaByIdAsync(id);
            if (imagen == null)
                return NotFound();

            return Ok(imagen);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImagenesEmpresa()
        {
            var imagenes = await _service.GetAllImagenes_EmpresaAsync();
            return Ok(imagenes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImagenesEmpresa([FromBody] Imagenes_Empresa imagenes_Empresa)
        {
            if (imagenes_Empresa == null)
                return BadRequest();

            await _service.CreateImagenes_EmpresaAsync(imagenes_Empresa);
            return CreatedAtAction(nameof(GetImagenesEmpresa), new { id = imagenes_Empresa.id_empresa }, imagenes_Empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImagenesEmpresa(Guid id, [FromBody] Imagenes_Empresa imagenes_Empresa)
        {
            if (id != imagenes_Empresa.id_empresa)
                return BadRequest();

            await _service.UpdateImagenes_EmpresaAsync(imagenes_Empresa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagenesEmpresa(Guid id)
        {
            await _service.DeleteImagenes_EmpresaAsync(id);
            return NoContent();
        }
    }
}
