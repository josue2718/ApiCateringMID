using Catering.Data.Repository.RPlatillo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cateing.Entity.Models;

namespace Catering.Data.Services
{
    public class PlatilloService: IPlatilloRepository
    {
        private readonly IPlatilloRepository _repository;

        public PlatilloService(IPlatilloRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Platillo> GetPlatilloByIdAsync(Guid id)
        {
            return await _repository.GetPlatilloByIdAsync(id);
        }

        public async Task<List<Platillo>> GetAllPlatilloAsync()
        {
            return await _repository.GetAllPlatilloAsync();
        }

        public async Task CreatePlatilloAsync(Platillo platillo)
        {
            await _repository.CreatePlatilloAsync(platillo);
        }

        public async Task UpdatePlatilloAsync(Platillo platillo)
        {
            await _repository.UpdatePlatilloAsync(platillo);
        }

        public async Task DeletePlatilloAsync(Guid id)
        {
            await _repository.DeletePlatilloAsync(id);
        }
    }
}
