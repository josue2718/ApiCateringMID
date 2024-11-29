using Catering.Data.Repository.RMenu_Reserva;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cateing.Entity.Models;

namespace Catering.Data.Services
{
    public class Menu_ReservaService: IMenu_ReservaRepository
    {
        private readonly IMenu_ReservaRepository _repository;

        public Menu_ReservaService(IMenu_ReservaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Menu_Reserva> GetMenu_ReservaByIdAsync(Guid id)
        {
            return await _repository.GetMenu_ReservaByIdAsync(id);
        }

        public async Task<List<Menu_Reserva>> GetAllMenu_ReservaAsync()
        {
            return await _repository.GetAllMenu_ReservaAsync();
        }

        public async Task CreateMenu_ReservaAsync(Menu_Reserva menuReserva)
        {
            await _repository.CreateMenu_ReservaAsync(menuReserva);
        }

        public async Task UpdateMenu_ReservaAsync(Menu_Reserva menuReserva)
        {
            await _repository.UpdateMenu_ReservaAsync(menuReserva);
        }

        public async Task DeleteMenu_ReservaAsync(Guid id)
        {
            await _repository.DeleteMenu_ReservaAsync(id);
        }
    }
}
