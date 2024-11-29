using Cateing.Entity.Models;
using Catering.Data.Repository.RBebida_Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Bebida_ReservaServices: IBebida_ReservaRepository
    {
        private readonly IBebida_ReservaRepository _repository;
        public Bebida_ReservaServices(IBebida_ReservaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Bebida_Reserva> GetBebida_ReservaByIdAsync(Guid id)
        {
            return await _repository.GetBebida_ReservaByIdAsync(id);
        }

        public async Task<List<Bebida_Reserva>> GetAllBebida_ReservaAsync()
        {
            return await _repository.GetAllBebida_ReservaAsync();
        }

        public async Task CreateBebida_ReservaAsync(Bebida_Reserva bebida_Reserva)
        {
            await _repository.CreateBebida_ReservaAsync(bebida_Reserva);
        }

        public async Task UpdateBebida_ReservaAsync(Bebida_Reserva bebida_Reserva)
        {
            await _repository.UpdateBebida_ReservaAsync(bebida_Reserva);
        }

        public async Task DeleteBebida_ReservaAsync(Guid id)
        {
            await _repository.DeleteBebida_ReservaAsync(id);
        }
    }
}
