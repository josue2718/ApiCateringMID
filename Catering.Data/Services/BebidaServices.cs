using Cateing.Entity.Models;
using Catering.Data.Repository.RBebidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class BebidaServices: IBebidaRepository
    {
        private readonly IBebidaRepository _repository;
        public BebidaServices(IBebidaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Bebida> GetBebidaByIdAsync(Guid id)
        {
            return await _repository.GetBebidaByIdAsync(id);
        }

        public async Task<List<Bebida>> GetAllBebidaAsync()
        {
            return await _repository.GetAllBebidaAsync();
        }

        public async Task CreateBebidaAsync(Bebida bebida)
        {
            await _repository.CreateBebidaAsync(bebida);
        }

        public async Task UpdateBebidaAsync(Bebida bebida)
        {
            await _repository.UpdateBebidaAsync(bebida);
        }

        public async Task DeleteBebidaAsync(Guid id)
        {
            await _repository.DeleteBebidaAsync(id);
        }
    }
}
