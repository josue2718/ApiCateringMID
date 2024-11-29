using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RPlatillo_Reserva
{
    public class Platillo_ReservaRepository : IPlatillo_ReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public Platillo_ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Platillo_Reserva> GetPlatillo_ReservaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var platilloReserva = await _context.Platillo_Reservas.FindAsync(id);
            if (platilloReserva == null)
            {
                throw new KeyNotFoundException($"Platillo_Reserva con el ID {id} no fue encontrado.");
            }
            return platilloReserva;
        }

        public async Task<List<Platillo_Reserva>> GetAllPlatillo_ReservaAsync()
        {
            try
            {
                return await _context.Platillo_Reservas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Platillo_Reserva.", ex);
            }
        }

        public async Task CreatePlatillo_ReservaAsync(Platillo_Reserva platilloReserva)
        {
            if (platilloReserva == null)
                throw new ArgumentNullException(nameof(platilloReserva), "Platillo_Reserva no puede ser nulo.");

            try
            {
                await _context.Platillo_Reservas.AddAsync(platilloReserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Platillo_Reserva en la base de datos.", ex);
            }
        }

        public async Task UpdatePlatillo_ReservaAsync(Platillo_Reserva platilloReserva)
        {
            if (platilloReserva == null)
                throw new ArgumentNullException(nameof(platilloReserva), "Platillo_Reserva no puede ser nulo.");

            try
            {
                _context.Platillo_Reservas.Update(platilloReserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Platillo_Reserva.", ex);
            }
        }

        public async Task DeletePlatillo_ReservaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var platilloReserva = await GetPlatillo_ReservaByIdAsync(id);
            if (platilloReserva == null)
                throw new KeyNotFoundException($"Platillo_Reserva con el ID {id} no existe.");

            try
            {
                _context.Platillo_Reservas.Remove(platilloReserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Platillo_Reserva de la base de datos.", ex);
            }
        }
    }
}
