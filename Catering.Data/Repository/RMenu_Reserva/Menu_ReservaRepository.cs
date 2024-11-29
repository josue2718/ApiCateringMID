using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RMenu_Reserva
{
    public class Menu_ReservaRepository : IMenu_ReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public Menu_ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu_Reserva> GetMenu_ReservaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var menu_Reserva = await _context.Menu_Reservas.FindAsync(id);
            if (menu_Reserva == null)
            {
                throw new KeyNotFoundException($"Menu_Reserva con el ID {id} no fue encontrado.");
            }
            return menu_Reserva;
        }

        public async Task<List<Menu_Reserva>> GetAllMenu_ReservaAsync()
        {
            try
            {
                return await _context.Menu_Reservas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Menu_Reserva.", ex);
            }
        }

        public async Task CreateMenu_ReservaAsync(Menu_Reserva menu_Reserva)
        {
            if (menu_Reserva == null)
                throw new ArgumentNullException(nameof(menu_Reserva), "Menu_Reserva no puede ser nulo.");

            try
            {
                await _context.Menu_Reservas.AddAsync(menu_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Menu_Reserva en la base de datos.", ex);
            }
        }

        public async Task UpdateMenu_ReservaAsync(Menu_Reserva menu_Reserva)
        {
            if (menu_Reserva == null)
                throw new ArgumentNullException(nameof(menu_Reserva), "Menu_Reserva no puede ser nulo.");

            try
            {
                _context.Menu_Reservas.Update(menu_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Menu_Reserva.", ex);
            }
        }

        public async Task DeleteMenu_ReservaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var menu_Reserva = await GetMenu_ReservaByIdAsync(id);
            if (menu_Reserva == null)
                throw new KeyNotFoundException($"Menu_Reserva con el ID {id} no existe.");

            try
            {
                _context.Menu_Reservas.Remove(menu_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Menu_Reserva de la base de datos.", ex);
            }
        }
    }
}
