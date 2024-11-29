using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RReserva_Info_Cliente
{
    public interface IReserva_Info_ClienteRepository
    {
        Task<Reserva_Info_Cliente> GetReserva_Info_ClienteByIdAsync(Guid id);
        Task<List<Reserva_Info_Cliente>> GetAllReserva_Info_ClienteAsync();
        Task CreateReserva_Info_ClienteAsync(Reserva_Info_Cliente reserva_Info_Cliente);
        Task UpdateReserva_Info_ClienteAsync(Reserva_Info_Cliente reserva_Info_Cliente);
        Task DeleteReserva_Info_ClienteAsync(Guid id);
    }
}
