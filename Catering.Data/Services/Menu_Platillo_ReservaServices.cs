using Catering.Data.Repository.RMenu_Platillo_Reserva;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cateing.Entity.Models;

namespace Catering.Data.Services
{
    public class Menu_Platillo_ReservaService: IMenu_Platillo_ReservaRepository
    {
        private readonly IMenu_Platillo_ReservaRepository _repository;

        public Menu_Platillo_ReservaService(IMenu_Platillo_ReservaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Menu_Platillo_Reserva> GetMenu_Platillo_ReservaByIdAsync(Guid id)
        {
            return await _repository.GetMenu_Platillo_ReservaByIdAsync(id);
        }

        public async Task<List<Menu_Platillo_Reserva>> GetAllMenu_Platillo_ReservaAsync()
        {
            return await _repository.GetAllMenu_Platillo_ReservaAsync();
        }

        public async Task CreateMenu_Platillo_ReservaAsync(Menu_Platillo_Reserva menuPlatilloReserva)
        {
            await _repository.CreateMenu_Platillo_ReservaAsync(menuPlatilloReserva);
        }

        public async Task UpdateMenu_Platillo_ReservaAsync(Menu_Platillo_Reserva menuPlatilloReserva)
        {
            await _repository.UpdateMenu_Platillo_ReservaAsync(menuPlatilloReserva);
        }

        public async Task DeleteMenu_Platillo_ReservaAsync(Guid id)
        {
            await _repository.DeleteMenu_Platillo_ReservaAsync(id);
        }
    }
}
