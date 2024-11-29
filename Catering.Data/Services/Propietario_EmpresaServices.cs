using Catering.Data.Repository.RPropietario_Empresa;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cateing.Entity.Models;

namespace Catering.Data.Services
{
    public class Propietario_EmpresaService: IPropietario_EmpresaRepository
    {
        private readonly IPropietario_EmpresaRepository _repository;

        public Propietario_EmpresaService(IPropietario_EmpresaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Propietario_Empresa> GetPropietario_EmpresaByIdAsync(Guid id)
        {
            return await _repository.GetPropietario_EmpresaByIdAsync(id);
        }

        public async Task<List<Propietario_Empresa>> GetAllPropietario_EmpresaAsync()
        {
            return await _repository.GetAllPropietario_EmpresaAsync();
        }

        public async Task CreatePropietario_EmpresaAsync(Propietario_Empresa propietarioEmpresa)
        {
            await _repository.CreatePropietario_EmpresaAsync(propietarioEmpresa);
        }

        public async Task UpdatePropietario_EmpresaAsync(Propietario_Empresa propietarioEmpresa)
        {
            await _repository.UpdatePropietario_EmpresaAsync(propietarioEmpresa);
        }

        public async Task DeletePropietario_EmpresaAsync(Guid id)
        {
            await _repository.DeletePropietario_EmpresaAsync(id);
        }
    }
}
