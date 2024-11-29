using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RMenu_Platillo_Reserva
{
    public interface IMenu_Platillo_ReservaRepository
    {
        Task<Menu_Platillo_Reserva> GetMenu_Platillo_ReservaByIdAsync(Guid id);
        Task<List<Menu_Platillo_Reserva>> GetAllMenu_Platillo_ReservaAsync();
        Task CreateMenu_Platillo_ReservaAsync(Menu_Platillo_Reserva menu_Platillo_Reserva);
        Task UpdateMenu_Platillo_ReservaAsync(Menu_Platillo_Reserva menu_Platillo_Reserva);
        Task DeleteMenu_Platillo_ReservaAsync(Guid id);
    }
}
