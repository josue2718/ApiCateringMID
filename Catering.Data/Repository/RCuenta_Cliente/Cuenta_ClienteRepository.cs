using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCuenta_Cliente
{
    public class Cuenta_ClienteRepository: ICuenta_ClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public Cuenta_ClienteRepository(ApplicationDbContext context)
        {
             _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
        }
        public async Task<Cuenta_Cliente> GetCuenta_ClienteByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var cuenta_Cliente = await _context.Cuenta_Cliente.FindAsync(id);
            if (cuenta_Cliente == null)
            {
                throw new KeyNotFoundException($"La Cuenta_Cliente con el ID {id} no fue encontrado.");
            }
            return cuenta_Cliente;
        }

        public async Task<List<Cuenta_Cliente>> GetAllCuenta_ClienteAsync()
        {
            try
            {
                return await _context.Cuenta_Cliente.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Cuenta_Cliente.", ex);
            }
        }

        public async Task CreateCuenta_ClienteAsync(Cuenta_Cliente cuenta_Cliente)
        {
            if (cuenta_Cliente == null)
                throw new ArgumentNullException(nameof(cuenta_Cliente), "Cuenta_Cliente no puede ser nulo.");

            try
            {
                await _context.Cuenta_Cliente.AddAsync(cuenta_Cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Cuenta_Cliente en la base de datos.", ex);
            }
        }

        public async Task UpdateCuenta_ClienteAsync(Cuenta_Cliente cuenta_Cliente)
        {
            if (cuenta_Cliente == null)
                throw new ArgumentNullException(nameof(cuenta_Cliente), "Cuenta_Cliente no puede ser nulo.");

            try
            {
                _context.Cuenta_Cliente.Update(cuenta_Cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Cuenta_Cliente.", ex);
            }
        }

        public async Task DeleteCuenta_ClienteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var cuenta_Cliente = await GetCuenta_ClienteByIdAsync(id);
            if (cuenta_Cliente == null)
                throw new KeyNotFoundException($"Cuenta_Cliente con el ID {id} no existe.");

            try
            {
                _context.Cuenta_Cliente.Remove(cuenta_Cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Cuenta_Cliente de la base de datos.", ex);
            }
        }
    }
}
