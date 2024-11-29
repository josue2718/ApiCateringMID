using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RPlatillo
{
    public interface IPlatilloRepository
    {
        Task<Platillo> GetPlatilloByIdAsync(Guid id);
        Task<List<Platillo>> GetAllPlatilloAsync();
        Task CreatePlatilloAsync(Platillo platillo);
        Task UpdatePlatilloAsync(Platillo platillo);
        Task DeletePlatilloAsync(Guid id);
    }
}
