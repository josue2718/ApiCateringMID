using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RReserva
{
    public class ReservaRepository : IReserva_Repository
    {
        private readonly ApplicationDbContext _context;
        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
        }
        public async Task<Reserva> GetReservaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                throw new KeyNotFoundException($"Reserva con el ID {id} no fue encontrado.");
            }
            return reserva;
        }

        public async Task<List<Reserva>> GetAllReservaAsync()
        {
            try
            {
                return await _context.Reserva.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Reserva.", ex);
            }
        }

        public async Task CreateReservaAsync(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "Reserva no puede ser nulo.");

            try
            {
                await _context.Reserva.AddAsync(reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Reserva en la base de datos.", ex);
            }
        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "Reserva no puede ser nulo.");

            try
            {
                _context.Reserva.Update(reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Reserva.", ex);
            }
        }

        public async Task DeleteReservaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var reserva = await GetReservaByIdAsync(id);
            if (reserva == null)
                throw new KeyNotFoundException($"Reserva con el ID {id} no existe.");

            try
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Reserva de la base de datos.", ex);
            }
        }
    }
}
