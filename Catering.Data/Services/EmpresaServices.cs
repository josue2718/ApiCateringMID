using Cateing.Entity.Models;
using Catering.Data.Repository.REmpresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class EmpresaServices: IEmpresaRepository
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaServices(IEmpresaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Empresa> GetEmpresaByIdAsync(Guid id)
        {
            return await _repository.GetEmpresaByIdAsync(id);
        }

        public async Task<List<Empresa>> GetAllEmpresaAsync()
        {
            return await _repository.GetAllEmpresaAsync();
        }

        public async Task CreateEmpresaAsync(Empresa empresa)
        {
            await _repository.CreateEmpresaAsync(empresa);
        }

        public async Task UpdateEmpresaAsync(Empresa empresa)
        {
            await _repository.UpdateEmpresaAsync(empresa);
        }

        public async Task DeleteEmpresaAsync(Guid id)
        {
            await _repository.DeleteEmpresaAsync(id);
        }
    }
}
