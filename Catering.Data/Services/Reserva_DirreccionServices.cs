using Cateing.Entity.Models;
using Catering.Data.Repository.RReserva_Dirreccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Reserva_DirreccionServices
    {
        private readonly IReserva_DirreccionRepository _repository;
        public Reserva_DirreccionServices(IReserva_DirreccionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reserva_Dirreccions> GetReserva_DirreccionsByIdAsync(Guid id)
        {
            return await _repository.GetReserva_DirreccionsByIdAsync(id);
        }

        public async Task<List<Reserva_Dirreccions>> GetAllReserva_DirreccionsAsync()
        {
            return await _repository.GetAllReserva_DirreccionsAsync();
        }

        public async Task CreatePlatillo_ReservaAsync(Reserva_Dirreccions reserva_Dirreccions)
        {
            await _repository.CreateReserva_DirreccionsAsync(reserva_Dirreccions);
        }

        public async Task UpdateReserva_DirreccionsAsync(Reserva_Dirreccions reserva_Dirreccions)
        {
            await _repository.UpdateReserva_DirreccionsAsync(reserva_Dirreccions);
        }

        public async Task DeleteReserva_DirreccionsAsync(Guid id)
        {
            await _repository.DeleteReserva_DirreccionsAsync(id);
        }
    }
}
