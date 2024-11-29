using Cateing.Entity.Models;
using Catering.Data.Repository.RReserva_Info_Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Reserva_Info_ClienteServices: IReserva_Info_ClienteRepository
    {
        private readonly IReserva_Info_ClienteRepository _repository;
        public Reserva_Info_ClienteServices(IReserva_Info_ClienteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Reserva_Info_Cliente> GetReserva_Info_ClienteByIdAsync(Guid id)
        {
            return await _repository.GetReserva_Info_ClienteByIdAsync(id);
        }

        public async Task<List<Reserva_Info_Cliente>> GetAllReserva_Info_ClienteAsync()
        {
            return await _repository.GetAllReserva_Info_ClienteAsync();
        }

        public async Task CreateReserva_Info_ClienteAsync(Reserva_Info_Cliente reserva_Info)
        {
            await _repository.CreateReserva_Info_ClienteAsync(reserva_Info);
        }

        public async Task UpdateReserva_Info_ClienteAsync(Reserva_Info_Cliente reserva_Info)
        {
            await _repository.UpdateReserva_Info_ClienteAsync(reserva_Info);
        }

        public async Task DeleteReserva_Info_ClienteAsync(Guid id)
        {
            await _repository.DeleteReserva_Info_ClienteAsync(id);
        }
    }
}
