using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RBebidas
{
    public class BebidaRepository : IBebidaRepository
    {
        private readonly ApplicationDbContext _context;
        public BebidaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
        }
        public async Task<Bebida> GetBebidaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                throw new KeyNotFoundException($"La Bebida con el ID {id} no fue encontrado.");
            }
            return bebida;
        }

        public async Task<List<Bebida>> GetAllBebidaAsync()
        {
            try
            {
                return await _context.Bebidas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Bebidas.", ex);
            }
        }

        public async Task CreateBebidaAsync(Bebida bebida)
        {
            if (bebida == null)
                throw new ArgumentNullException(nameof(bebida), "La Bebida no puede ser nulo.");

            try
            {
                await _context.Bebidas.AddAsync(bebida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear la Bebida en la base de datos.", ex);
            }
        }

        public async Task UpdateBebidaAsync(Bebida bebida)
        {
            if (bebida == null)
                throw new ArgumentNullException(nameof(bebida), "La Bebida no puede ser nulo.");

            try
            {
                _context.Bebidas.Update(bebida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar la Bebida.", ex);
            }
        }

        public async Task DeleteBebidaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var bebida = await GetBebidaByIdAsync(id);
            if (bebida == null)
                throw new KeyNotFoundException($"La Bebida con el ID {id} no existe.");

            try
            {
                _context.Bebidas.Remove(bebida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar la Bebida de la base de datos.", ex);
            }
        }
    }
}
