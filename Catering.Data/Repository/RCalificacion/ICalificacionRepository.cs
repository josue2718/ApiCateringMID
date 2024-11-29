using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCalificacion
{
    public interface ICalificacionRepository
    {
        Task<Calificacion> GetCalificacionByIdAsync(Guid id);
        Task<List<Calificacion>> GetAllCalificacionAsync();
        Task CreateCalificacionAsync(Calificacion calificacion);
        Task UpdateCalificacionAsync(Calificacion calificacion);
        Task DeleteCalificacionAsync(Guid id);
    }
}
