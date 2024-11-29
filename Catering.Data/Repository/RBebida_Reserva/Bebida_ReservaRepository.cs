using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RBebida_Reserva
{
    public class Bebida_ReservaRepository : IBebida_ReservaRepository
    {
        private readonly ApplicationDbContext _context;
        public Bebida_ReservaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
        }
        public async Task<Bebida_Reserva> GetBebida_ReservaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var bebida = await _context.Bebida_Reserva.FindAsync(id);
            if (bebida == null)
            {
                throw new KeyNotFoundException($"El Bebida_Reserva con el ID {id} no fue encontrado.");
            }
            return bebida;
        }

        public async Task<List<Bebida_Reserva>> GetAllBebida_ReservaAsync()
        {
            try
            {
                return await _context.Bebida_Reserva.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Bebida_Reserva.", ex);
            }
        }

        public async Task CreateBebida_ReservaAsync(Bebida_Reserva bebida)
        {
            if (bebida == null)
                throw new ArgumentNullException(nameof(bebida), "El Bebida_Reserva no puede ser nulo.");

            try
            {
                await _context.Bebida_Reserva.AddAsync(bebida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear el Bebida_Reserva en la base de datos.", ex);
            }
        }

        public async Task UpdateBebida_ReservaAsync(Bebida_Reserva bebida)
        {
            if (bebida == null)
                throw new ArgumentNullException(nameof(bebida), "El Bebida_Reserva no puede ser nulo.");

            try
            {
                _context.Bebida_Reserva.Update(bebida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar el Bebida_Reserva.", ex);
            }
        }

        public async Task DeleteBebida_ReservaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var bebida = await GetBebida_ReservaByIdAsync(id);
            if (bebida == null)
                throw new KeyNotFoundException($"El Bebida_Reserva con el ID {id} no existe.");

            try
            {
                _context.Bebida_Reserva.Remove(bebida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar el Bebida_Reserva de la base de datos.", ex);
            }
        }
    }
}
