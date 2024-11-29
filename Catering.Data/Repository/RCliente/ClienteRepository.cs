using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCliente
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context),"El contexto no puede ser nulo");
        }
        public async Task<Cliente> GetClienteByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"El Cliente con el ID {id} no fue encontrado.");
            }
            return cliente;
        }

        public async Task<List<Cliente>> GetAllClienteAsync()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Cliente.", ex);
            }
        }

        public async Task CreateClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El Cliente no puede ser nulo.");

            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear el Cliente en la base de datos.", ex);
            }
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El Cliente no puede ser nulo.");

            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar el Cliente.", ex);
            }
        }

        public async Task DeleteClienteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var cliente = await GetClienteByIdAsync(id);
            if (cliente == null)
                throw new KeyNotFoundException($"El Cliente con el ID {id} no existe.");

            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar el Cliente de la base de datos.", ex);
            }
        }
    }
}
