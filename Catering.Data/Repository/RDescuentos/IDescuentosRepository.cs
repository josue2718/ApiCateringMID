using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RDescuentos
{
    public interface IDescuentosRepository
    {
        Task<Descuentos> GetDescuentosByIdAsync(Guid id);
        Task<List<Descuentos>> GetAllDescuentosAsync();
        Task CreateDescuentosAsync(Descuentos descuentos);
        Task UpdateDescuentosAsync(Descuentos descuentos);
        Task DeleteDescuentosAsync(Guid id);
    }
}
