using Cateing.Entity.Models;
using Catering.Data.Repository.RCuenta_Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Cuenta_ClienteServices: ICuenta_ClienteRepository
    {
        private readonly ICuenta_ClienteRepository _repository;
        public Cuenta_ClienteServices(ICuenta_ClienteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Cuenta_Cliente> GetCuenta_ClienteByIdAsync(Guid id)
        {
            return await _repository.GetCuenta_ClienteByIdAsync(id);
        }

        public async Task<List<Cuenta_Cliente>> GetAllCuenta_ClienteAsync()
        {
            return await _repository.GetAllCuenta_ClienteAsync();
        }

        public async Task CreateCuenta_ClienteAsync(Cuenta_Cliente cuenta_Cliente)
        {
            await _repository.CreateCuenta_ClienteAsync(cuenta_Cliente);
        }

        public async Task UpdateCuenta_ClienteAsync(Cuenta_Cliente cuenta_Cliente)
        {
            await _repository.UpdateCuenta_ClienteAsync(cuenta_Cliente);
        }

        public async Task DeleteCuenta_ClienteAsync(Guid id)
        {
            await _repository.DeleteCuenta_ClienteAsync(id);
        }
    }
}
