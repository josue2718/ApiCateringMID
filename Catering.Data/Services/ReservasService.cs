using Cateing.Entity.Models;
using Catering.Data.Repository.RReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class ReservasService
    {
        private readonly IReserva_Repository _repository;
        public ReservasService(IReserva_Repository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Reserva> GetReservaByIdAsync(Guid id)
        {
            return await _repository.GetReservaByIdAsync(id);
        }

        public async Task<List<Reserva>> GetAllReservaAsync()
        {
            return await _repository.GetAllReservaAsync();
        }

        public async Task CreateReservaAsync(Reserva reserva)
        {
            await _repository.CreateReservaAsync(reserva);
        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            await _repository.UpdateReservaAsync(reserva);
        }

        public async Task DeleteReservaAsync(Guid id)
        {
            await _repository.DeleteReservaAsync(id);
        }
    }
}
