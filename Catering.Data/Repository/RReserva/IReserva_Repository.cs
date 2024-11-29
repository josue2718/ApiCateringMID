using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RReserva
{
    public interface IReserva_Repository
    {
        Task<Reserva> GetReservaByIdAsync(Guid id);
        Task<List<Reserva>> GetAllReservaAsync();
        Task CreateReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task DeleteReservaAsync(Guid id);
    }
}
