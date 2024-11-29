using Cateing.Entity.Models;
using Catering.Data.Repository.RCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class ClienteServices
    {
        private readonly IClienteRepository _repository;
        public ClienteServices(IClienteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Cliente> GetClienteByIdAsync(Guid id)
        {
            return await _repository.GetClienteByIdAsync(id);
        }

        public async Task<List<Cliente>> GetAllClienteAsync()
        {
            return await _repository.GetAllClienteAsync();
        }

        public async Task CreateClienteAsync(Cliente cliente)
        {
            await _repository.CreateClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _repository.UpdateClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(Guid id)
        {
            await _repository.DeleteClienteAsync(id);
        }
    }
}
