using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCalificacion
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly ApplicationDbContext _context;
        public CalificacionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser niulo");
        }
        public async Task<Calificacion> GetCalificacionByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var calificacion = await _context.Calificacion.FindAsync(id);
            if (calificacion == null)
            {
                throw new KeyNotFoundException($"La Calificacion con el ID {id} no fue encontrado.");
            }
            return calificacion;
        }

        public async Task<List<Calificacion>> GetAllCalificacionAsync()
        {
            try
            {
                return await _context.Calificacion.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Calificacion.", ex);
            }
        }

        public async Task CreateCalificacionAsync(Calificacion calificacion)
        {
            if (calificacion == null)
                throw new ArgumentNullException(nameof(calificacion), "La Bebida no puede ser nulo.");

            try
            {
                await _context.Calificacion.AddAsync(calificacion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear la Calificacion en la base de datos.", ex);
            }
        }

        public async Task UpdateCalificacionAsync(Calificacion calificacion)
        {
            if (calificacion == null)
                throw new ArgumentNullException(nameof(calificacion), "La Calificacion no puede ser nulo.");

            try
            {
                _context.Calificacion.Update(calificacion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar la Calificacion.", ex);
            }
        }

        public async Task DeleteCalificacionAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var calificacion = await GetCalificacionByIdAsync(id);
            if (calificacion == null)
                throw new KeyNotFoundException($"La Calificacion con el ID {id} no existe.");

            try
            {
                _context.Calificacion.Remove(calificacion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar la Calificacion de la base de datos.", ex);
            }
        }
    }
}
