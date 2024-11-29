using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RPlatillo
{
    public class PlatilloRepository : IPlatilloRepository
    {
        private readonly ApplicationDbContext _context;

        public PlatilloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Platillo> GetPlatilloByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var platillo = await _context.Platillos.FindAsync(id);
            if (platillo == null)
            {
                throw new KeyNotFoundException($"Platillo con el ID {id} no fue encontrado.");
            }
            return platillo;
        }

        public async Task<List<Platillo>> GetAllPlatilloAsync()
        {
            try
            {
                return await _context.Platillos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Platillo.", ex);
            }
        }

        public async Task CreatePlatilloAsync(Platillo platillo)
        {
            if (platillo == null)
                throw new ArgumentNullException(nameof(platillo), "Platillo no puede ser nulo.");

            try
            {
                await _context.Platillos.AddAsync(platillo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Platillo en la base de datos.", ex);
            }
        }

        public async Task UpdatePlatilloAsync(Platillo platillo)
        {
            if (platillo == null)
                throw new ArgumentNullException(nameof(platillo), "Platillo no puede ser nulo.");

            try
            {
                _context.Platillos.Update(platillo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Platillo.", ex);
            }
        }

        public async Task DeletePlatilloAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var platillo = await GetPlatilloByIdAsync(id);
            if (platillo == null)
                throw new KeyNotFoundException($"Platillo con el ID {id} no existe.");

            try
            {
                _context.Platillos.Remove(platillo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Platillo de la base de datos.", ex);
            }
        }
    }
}
