using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCuenta_Propietario
{
    public class Cuenta_PropietarioRepository: ICuenta_PropietarioRepository
    {
        private readonly ApplicationDbContext _context;
        public Cuenta_PropietarioRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
        }
        public async Task<Cuenta_Propietario> GetCuenta_PropietarioByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var cuenta_Propietario = await _context.Cuenta_Propietarios.FindAsync(id);
            if (cuenta_Propietario == null)
            {
                throw new KeyNotFoundException($"La Cuenta_Propietario con el ID {id} no fue encontrado.");
            }
            return cuenta_Propietario;
        }

        public async Task<List<Cuenta_Propietario>> GetAllCuenta_PropietarioAsync()
        {
            try
            {
                return await _context.Cuenta_Propietarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Cuenta_Propietarios.", ex);
            }
        }

        public async Task CreateCuenta_PropietarioAsync(Cuenta_Propietario cuenta_Propietario)
        {
            if (cuenta_Propietario == null)
                throw new ArgumentNullException(nameof(cuenta_Propietario), "Cuenta_Propietario no puede ser nulo.");

            try
            {
                await _context.Cuenta_Propietarios.AddAsync(cuenta_Propietario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Cuenta_Propietario en la base de datos.", ex);
            }
        }

        public async Task UpdateCuenta_PropietarioAsync(Cuenta_Propietario cuenta_Propietario)
        {
            if (cuenta_Propietario == null)
                throw new ArgumentNullException(nameof(cuenta_Propietario), "Cuenta_Propietario no puede ser nulo.");

            try
            {
                _context.Cuenta_Propietarios.Update(cuenta_Propietario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Cuenta_Propietario.", ex);
            }
        }

        public async Task DeleteCuenta_PropietarioAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var cuenta_Propietario = await GetCuenta_PropietarioByIdAsync(id);
            if (cuenta_Propietario == null)
                throw new KeyNotFoundException($"Cuenta_Propietario con el ID {id} no existe.");

            try
            {
                _context.Cuenta_Propietarios.Remove(cuenta_Propietario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Cuenta_Propietario de la base de datos.", ex);
            }
        }
    }
}
