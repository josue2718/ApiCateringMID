using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Catering.Data.Repository.RReserva_Dirreccion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.Reserva_Dirreccion
{
    public class Reserva_DirreccionRepository : IReserva_DirreccionRepository
    {
        private readonly ApplicationDbContext _context;
        public Reserva_DirreccionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
        }
        public async Task<Reserva_Dirreccions> GetReserva_DirreccionsByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var reserva_Dirreccion = await _context.Reserva_Dirreccion.FindAsync(id);
            if (reserva_Dirreccion == null)
            {
                throw new KeyNotFoundException($"Reserva_Dirreccions con el ID {id} no fue encontrado.");
            }
            return reserva_Dirreccion;
        }

        public async Task<List<Reserva_Dirreccions>> GetAllReserva_DirreccionsAsync()
        {
            try
            {
                return await _context.Reserva_Dirreccion.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Reserva_Dirreccions.", ex);
            }
        }

        public async Task CreateReserva_DirreccionsAsync(Reserva_Dirreccions reserva_Dirreccions)
        {
            if (reserva_Dirreccions == null)
                throw new ArgumentNullException(nameof(reserva_Dirreccions), "Reserva_Dirreccions no puede ser nulo.");

            try
            {
                await _context.Reserva_Dirreccion.AddAsync(reserva_Dirreccions);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Reserva_Dirreccions en la base de datos.", ex);
            }
        }

        public async Task UpdateReserva_DirreccionsAsync(Reserva_Dirreccions reserva_Dirreccions)
        {
            if (reserva_Dirreccions == null)
                throw new ArgumentNullException(nameof(reserva_Dirreccions), "Reserva_Dirreccions no puede ser nulo.");

            try
            {
                _context.Reserva_Dirreccion.Update(reserva_Dirreccions);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Reserva_Dirreccions.", ex);
            }
        }

        public async Task DeleteReserva_DirreccionsAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var reserva_Dirreccions = await GetReserva_DirreccionsByIdAsync(id);
            if (reserva_Dirreccions == null)
                throw new KeyNotFoundException($"Reserva_Dirreccions con el ID {id} no existe.");

            try
            {
                _context.Reserva_Dirreccion.Remove(reserva_Dirreccions);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Reserva_Dirreccions de la base de datos.", ex);
            }
        }
    }
}
