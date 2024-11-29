using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RMenu_Bebida_Reserva
{
    public interface IMenu_Bebida_ReservaRepository
    {
        Task<Menu_Bebida_Reserva> GetMenu_Bebida_ReservaByIdAsync(Guid id);
        Task<List<Menu_Bebida_Reserva>> GetAllMenu_Bebida_ReservaAsync();
        Task CreateMenu_Bebida_ReservaAsync(Menu_Bebida_Reserva menu_Bebida_Reserva);
        Task UpdateMenu_Bebida_ReservaAsync(Menu_Bebida_Reserva menu_Bebida_Reserva);
        Task DeleteMenu_Bebida_ReservaAsync(Guid id);
    }
}
