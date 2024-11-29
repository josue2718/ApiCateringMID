using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RPlatillo_Reserva
{
    public interface IPlatillo_ReservaRepository
    {
        Task<Platillo_Reserva> GetPlatillo_ReservaByIdAsync(Guid id);
        Task<List<Platillo_Reserva>> GetAllPlatillo_ReservaAsync();
        Task CreatePlatillo_ReservaAsync(Platillo_Reserva platillo_Reserva);
        Task UpdatePlatillo_ReservaAsync(Platillo_Reserva platillo_Reserva);
        Task DeletePlatillo_ReservaAsync(Guid id);
    }
}
