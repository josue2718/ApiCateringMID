using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RMenu_Bebida_Reserva
{
    public class Menu_Bebida_ReservaRepository : IMenu_Bebida_ReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public Menu_Bebida_ReservaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context),"El contexto no puede ser nulo");
        }

        public async Task<Menu_Bebida_Reserva> GetMenu_Bebida_ReservaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var menu_Bebida_Reserva = await _context.Menu_Bebida_Reservas.FindAsync(id);
            if (menu_Bebida_Reserva == null)
            {
                throw new KeyNotFoundException($"Menu_Bebida_Reserva con el ID {id} no fue encontrado.");
            }
            return menu_Bebida_Reserva;
        }

        public async Task<List<Menu_Bebida_Reserva>> GetAllMenu_Bebida_ReservaAsync()
        {
            try
            {
                return await _context.Menu_Bebida_Reservas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Menu_Bebida_Reserva.", ex);
            }
        }

        public async Task CreateMenu_Bebida_ReservaAsync(Menu_Bebida_Reserva menu_Bebida_Reserva)
        {
            if (menu_Bebida_Reserva == null)
                throw new ArgumentNullException(nameof(menu_Bebida_Reserva), "Menu_Bebida_Reserva no puede ser nulo.");

            try
            {
                await _context.Menu_Bebida_Reservas.AddAsync(menu_Bebida_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Menu_Bebida_Reserva en la base de datos.", ex);
            }
        }

        public async Task UpdateMenu_Bebida_ReservaAsync(Menu_Bebida_Reserva menu_Bebida_Reserva)
        {
            if (menu_Bebida_Reserva == null)
                throw new ArgumentNullException(nameof(menu_Bebida_Reserva), "Menu_Bebida_Reserva no puede ser nulo.");

            try
            {
                _context.Menu_Bebida_Reservas.Update(menu_Bebida_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Menu_Bebida_Reserva.", ex);
            }
        }

        public async Task DeleteMenu_Bebida_ReservaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var menu_Bebida_Reserva = await GetMenu_Bebida_ReservaByIdAsync(id);
            if (menu_Bebida_Reserva == null)
                throw new KeyNotFoundException($"Menu_Bebida_Reserva con el ID {id} no existe.");

            try
            {
                _context.Menu_Bebida_Reservas.Remove(menu_Bebida_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Menu_Bebida_Reserva de la base de datos.", ex);
            }
        }
    }
}
