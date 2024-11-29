using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RDescuentos
{
    public class DescuentosRepository : IDescuentosRepository
    {
        private readonly ApplicationDbContext _context;
        public DescuentosRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context),"El contexto no puede ser nulo");
        }
        public async Task<Descuentos> GetDescuentosByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var descuentos = await _context.Descuentos.FindAsync(id);
            if (descuentos == null)
            {
                throw new KeyNotFoundException($"Descuento con el ID {id} no fue encontrado.");
            }
            return descuentos;
        }

        public async Task<List<Descuentos>> GetAllDescuentosAsync()
        {
            try
            {
                return await _context.Descuentos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Descuentos.", ex);
            }
        }

        public async Task CreateDescuentosAsync(Descuentos descuentos)
        {
            if (descuentos == null)
                throw new ArgumentNullException(nameof(descuentos), "Descuentos no puede ser nulo.");

            try
            {
                await _context.Descuentos.AddAsync(descuentos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Descuentos en la base de datos.", ex);
            }
        }

        public async Task UpdateDescuentosAsync(Descuentos descuentos)
        {
            if (descuentos == null)
                throw new ArgumentNullException(nameof(descuentos), "Descuento no puede ser nulo.");

            try
            {
                _context.Descuentos.Update(descuentos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Descuentos.", ex);
            }
        }

        public async Task DeleteDescuentosAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var descuentos = await GetDescuentosByIdAsync(id);
            if (descuentos == null)
                throw new KeyNotFoundException($"Descuentos con el ID {id} no existe.");

            try
            {
                _context.Descuentos.Remove(descuentos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Descuentos de la base de datos.", ex);
            }
        }
    }
}
