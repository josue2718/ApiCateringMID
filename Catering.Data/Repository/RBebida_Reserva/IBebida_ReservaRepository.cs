using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RBebida_Reserva
{
    public interface IBebida_ReservaRepository
    {
        Task<Bebida_Reserva> GetBebida_ReservaByIdAsync(Guid id);
        Task<List<Bebida_Reserva>> GetAllBebida_ReservaAsync();
        Task CreateBebida_ReservaAsync(Bebida_Reserva bebida_reserva);
        Task UpdateBebida_ReservaAsync(Bebida_Reserva bebida_reserva);
        Task DeleteBebida_ReservaAsync(Guid id);
    }
}
