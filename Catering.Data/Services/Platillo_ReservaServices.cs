using Cateing.Entity.Models;
using Catering.Data.Repository.RPlatillo_Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Platillo_ReservaServices: IPlatillo_ReservaRepository
    {
        private readonly IPlatillo_ReservaRepository _repository;
        public Platillo_ReservaServices(IPlatillo_ReservaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Platillo_Reserva> GetPlatillo_ReservaByIdAsync(Guid id)
        {
            return await _repository.GetPlatillo_ReservaByIdAsync(id);
        }

        public async Task<List<Platillo_Reserva>> GetAllPlatillo_ReservaAsync()
        {
            return await _repository.GetAllPlatillo_ReservaAsync();
        }

        public async Task CreatePlatillo_ReservaAsync(Platillo_Reserva platillo_Reserva)
        {
            await _repository.CreatePlatillo_ReservaAsync(platillo_Reserva);
        }

        public async Task UpdatePlatillo_ReservaAsync(Platillo_Reserva platillo_Reserva)
        {
            await _repository.UpdatePlatillo_ReservaAsync(platillo_Reserva);
        }

        public async Task DeletePlatillo_ReservaAsync(Guid id)
        {
            await _repository.DeletePlatillo_ReservaAsync(id);
        }
    }
}
