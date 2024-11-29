using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RMenu_Platillo_Reserva
{
    public class Menu_Platillo_ReservaRepository : IMenu_Platillo_ReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public Menu_Platillo_ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu_Platillo_Reserva> GetMenu_Platillo_ReservaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var menu_Platillo_Reserva = await _context.Menu_Platillo_Reservas.FindAsync(id);
            if (menu_Platillo_Reserva == null)
            {
                throw new KeyNotFoundException($"Menu_Platillo_Reserva con el ID {id} no fue encontrado.");
            }
            return menu_Platillo_Reserva;
        }

        public async Task<List<Menu_Platillo_Reserva>> GetAllMenu_Platillo_ReservaAsync()
        {
            try
            {
                return await _context.Menu_Platillo_Reservas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Menu_Platillo_Reserva.", ex);
            }
        }

        public async Task CreateMenu_Platillo_ReservaAsync(Menu_Platillo_Reserva menu_Platillo_Reserva)
        {
            if (menu_Platillo_Reserva == null)
                throw new ArgumentNullException(nameof(menu_Platillo_Reserva), "Menu_Platillo_Reserva no puede ser nulo.");

            try
            {
                await _context.Menu_Platillo_Reservas.AddAsync(menu_Platillo_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Menu_Platillo_Reserva en la base de datos.", ex);
            }
        }

        public async Task UpdateMenu_Platillo_ReservaAsync(Menu_Platillo_Reserva menu_Platillo_Reserva)
        {
            if (menu_Platillo_Reserva == null)
                throw new ArgumentNullException(nameof(menu_Platillo_Reserva), "Menu_Platillo_Reserva no puede ser nulo.");

            try
            {
                _context.Menu_Platillo_Reservas.Update(menu_Platillo_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Menu_Platillo_Reserva.", ex);
            }
        }

        public async Task DeleteMenu_Platillo_ReservaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var menu_Platillo_Reserva = await GetMenu_Platillo_ReservaByIdAsync(id);
            if (menu_Platillo_Reserva == null)
                throw new KeyNotFoundException($"Menu_Platillo_Reserva con el ID {id} no existe.");

            try
            {
                _context.Menu_Platillo_Reservas.Remove(menu_Platillo_Reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Menu_Platillo_Reserva de la base de datos.", ex);
            }
        }
    }
}
