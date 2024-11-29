using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RMenu_Reserva
{
    public interface IMenu_ReservaRepository
    {
        Task<Menu_Reserva> GetMenu_ReservaByIdAsync(Guid id);
        Task<List<Menu_Reserva>> GetAllMenu_ReservaAsync();
        Task CreateMenu_ReservaAsync(Menu_Reserva menu_Reserva);
        Task UpdateMenu_ReservaAsync(Menu_Reserva menu_Reserva);
        Task DeleteMenu_ReservaAsync(Guid id);
    }
}
