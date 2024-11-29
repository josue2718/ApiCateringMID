using Cateing.Entity.Models;
using Catering.Data.Repository.RDescuentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class DescuentosService: IDescuentosRepository
    {
        private readonly IDescuentosRepository _repository;
        public DescuentosService(IDescuentosRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Descuentos> GetDescuentosByIdAsync(Guid id)
        {
            return await _repository.GetDescuentosByIdAsync(id);
        }

        public async Task<List<Descuentos>> GetAllDescuentosAsync()
        {
            return await _repository.GetAllDescuentosAsync();
        }

        public async Task CreateDescuentosAsync(Descuentos descuentos)
        {
            await _repository.CreateDescuentosAsync(descuentos);
        }

        public async Task UpdateDescuentosAsync(Descuentos descuentos)
        {
            await _repository.UpdateDescuentosAsync(descuentos);
        }

        public async Task DeleteDescuentosAsync(Guid id)
        {
            await _repository.DeleteDescuentosAsync(id);
        }
    }
}
