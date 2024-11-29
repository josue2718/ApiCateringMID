using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RReserva_Dirreccion
{
    public interface IReserva_DirreccionRepository
    {
        Task<Reserva_Dirreccions> GetReserva_DirreccionsByIdAsync(Guid id);
        Task<List<Reserva_Dirreccions>> GetAllReserva_DirreccionsAsync();
        Task CreateReserva_DirreccionsAsync(Reserva_Dirreccions reserva_Dirreccions);
        Task UpdateReserva_DirreccionsAsync(Reserva_Dirreccions reserva_Dirreccions);
        Task DeleteReserva_DirreccionsAsync(Guid id);
    }
}
