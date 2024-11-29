using Cateing.Entity.Models;
using Catering.Data.Repository.RCuenta_Propietario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Cuenta_PropietarioServices: ICuenta_PropietarioRepository
    {
        private readonly ICuenta_PropietarioRepository _repository;
        public Cuenta_PropietarioServices(ICuenta_PropietarioRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Cuenta_Propietario> GetCuenta_PropietarioByIdAsync(Guid id)
        {
            return await _repository.GetCuenta_PropietarioByIdAsync(id);
        }

        public async Task<List<Cuenta_Propietario>> GetAllCuenta_PropietarioAsync()
        {
            return await _repository.GetAllCuenta_PropietarioAsync();
        }

        public async Task CreateCuenta_PropietarioAsync(Cuenta_Propietario cuenta_Propietario)
        {
            await _repository.CreateCuenta_PropietarioAsync(cuenta_Propietario);
        }

        public async Task UpdateCuenta_PropietarioAsync(Cuenta_Propietario cuenta_Propietario)
        {
            await _repository.UpdateCuenta_PropietarioAsync(cuenta_Propietario);
        }

        public async Task DeleteCuenta_PropietarioAsync(Guid id)
        {
            await _repository.DeleteCuenta_PropietarioAsync(id);
        }
    }
}
