using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RReserva_Info_Cliente
{
    public class Reserva_Info_ClienteRepository: IReserva_Info_ClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public Reserva_Info_ClienteRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
        }
        public async Task<Reserva_Info_Cliente> GetReserva_Info_ClienteByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var reserva_info = await _context.Reserva_Info_Clientes.FindAsync(id);
            if (reserva_info == null)
            {
                throw new KeyNotFoundException($"Reserva_Info_Cliente con el ID {id} no fue encontrado.");
            }
            return reserva_info;
        }

        public async Task<List<Reserva_Info_Cliente>> GetAllReserva_Info_ClienteAsync()
        {
            try
            {
                return await _context.Reserva_Info_Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Reserva_Info_Cliente.", ex);
            }
        }

        public async Task CreateReserva_Info_ClienteAsync(Reserva_Info_Cliente reserva_Info)
        {
            if (reserva_Info == null)
                throw new ArgumentNullException(nameof(reserva_Info), "Reserva_Info_Cliente no puede ser nulo.");

            try
            {
                await _context.Reserva_Info_Clientes.AddAsync(reserva_Info);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Reserva_Info_Cliente en la base de datos.", ex);
            }
        }

        public async Task UpdateReserva_Info_ClienteAsync(Reserva_Info_Cliente reserva_Info)
        {
            if (reserva_Info == null)
                throw new ArgumentNullException(nameof(reserva_Info), "Reserva_Info_Cliente no puede ser nulo.");

            try
            {
                _context.Reserva_Info_Clientes.Update(reserva_Info);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizarReserva_Info_Cliente.", ex);
            }
        }

        public async Task DeleteReserva_Info_ClienteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var reserva_Info = await GetReserva_Info_ClienteByIdAsync(id);
            if (reserva_Info == null)
                throw new KeyNotFoundException($"Reserva_Info_Cliente con el ID {id} no existe.");

            try
            {
                _context.Reserva_Info_Clientes.Remove(reserva_Info);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Reserva_Info_Cliente de la base de datos.", ex);
            }
        }
    }
}
