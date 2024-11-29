using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RImagenes_Empresa
{
    public class Imagenes_EmpresaRepository: IImagenes_EmpresaRepository
    {
        private readonly ApplicationDbContext _context;
        public Imagenes_EmpresaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context),"El contexto no puede ser nulo");
        }
        public async Task<Imagenes_Empresa> GetImagenes_EmpresaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var imagen_empresa = await _context.Imagenes_Empresas.FindAsync(id);
            if (imagen_empresa == null)
            {
                throw new KeyNotFoundException($"Imagenes_Empresa con el ID {id} no fue encontrado.");
            }
            return imagen_empresa;
        }

        public async Task<List<Imagenes_Empresa>> GetAllImagenes_EmpresaAsync()
        {
            try
            {
                return await _context.Imagenes_Empresas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Imagenes_Empresa.", ex);
            }
        }

        public async Task CreateImagenes_EmpresaAsync(Imagenes_Empresa imagen_Empresa)
        {
            if (imagen_Empresa == null)
                throw new ArgumentNullException(nameof(imagen_Empresa), "Imagenes_Empresa no puede ser nulo.");

            try
            {
                await _context.Imagenes_Empresas.AddAsync(imagen_Empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Imagenes_Empresa en la base de datos.", ex);
            }
        }

        public async Task UpdateImagenes_EmpresaAsync(Imagenes_Empresa imagenes_Empresa)
        {
            if (imagenes_Empresa == null)
                throw new ArgumentNullException(nameof(imagenes_Empresa), "Imagenes_Empresa no puede ser nulo.");

            try
            {
                _context.Imagenes_Empresas.Update(imagenes_Empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Imagenes_Empresa.", ex);
            }
        }

        public async Task DeleteImagenes_EmpresaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var imagen_Empresa = await GetImagenes_EmpresaByIdAsync(id);
            if (imagen_Empresa == null)
                throw new KeyNotFoundException($"Imagenes_Empresa con el ID {id} no existe.");

            try
            {
                _context.Imagenes_Empresas.Remove(imagen_Empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Imagenes_Empresa de la base de datos.", ex);
            }
        }
    }
}
