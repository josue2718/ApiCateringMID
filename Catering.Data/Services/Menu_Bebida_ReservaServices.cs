
using Catering.Data.Repository.RMenu_Bebida_Reserva;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cateing.Entity.Models;

namespace Catering.Data.Services
{
    public class Menu_Bebida_ReservaService: IMenu_Bebida_ReservaRepository
    {
        private readonly IMenu_Bebida_ReservaRepository _repository;

        public Menu_Bebida_ReservaService(IMenu_Bebida_ReservaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Menu_Bebida_Reserva> GetMenu_Bebida_ReservaByIdAsync(Guid id)
        {
            return await _repository.GetMenu_Bebida_ReservaByIdAsync(id);
        }

        public async Task<List<Menu_Bebida_Reserva>> GetAllMenu_Bebida_ReservaAsync()
        {
            return await _repository.GetAllMenu_Bebida_ReservaAsync();
        }

        public async Task CreateMenu_Bebida_ReservaAsync(Menu_Bebida_Reserva menuBebidaReserva)
        {
            await _repository.CreateMenu_Bebida_ReservaAsync(menuBebidaReserva);
        }

        public async Task UpdateMenu_Bebida_ReservaAsync(Menu_Bebida_Reserva menuBebidaReserva)
        {
            await _repository.UpdateMenu_Bebida_ReservaAsync(menuBebidaReserva);
        }

        public async Task DeleteMenu_Bebida_ReservaAsync(Guid id)
        {
            await _repository.DeleteMenu_Bebida_ReservaAsync(id);
        }
    }
}
