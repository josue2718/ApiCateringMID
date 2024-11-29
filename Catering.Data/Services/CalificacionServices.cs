using Cateing.Entity.Models;
using Catering.Data.Repository.RCalificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class CalificacionServices: ICalificacionRepository
    {
        private readonly ICalificacionRepository _repository;
        public CalificacionServices(ICalificacionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Calificacion> GetCalificacionByIdAsync(Guid id)
        {
            return await _repository.GetCalificacionByIdAsync(id);
        }

        public async Task<List<Calificacion>> GetAllCalificacionAsync()
        {
            return await _repository.GetAllCalificacionAsync();
        }

        public async Task CreateCalificacionAsync(Calificacion calificacion)
        {
            await _repository.CreateCalificacionAsync(calificacion);
        }

        public async Task UpdateCalificacionAsync(Calificacion calificacion)
        {
            await _repository.UpdateCalificacionAsync(calificacion);
        }

        public async Task DeleteCalificacionAsync(Guid id)
        {
            await _repository.DeleteCalificacionAsync(id);
        }
    }
}
