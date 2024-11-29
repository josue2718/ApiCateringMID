using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCliente
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByIdAsync(Guid id);
        Task<List<Cliente>> GetAllClienteAsync();
        Task CreateClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(Guid id);
    }
}
