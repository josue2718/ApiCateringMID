using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RBebidas
{
    public interface IBebidaRepository
    {
        Task<Bebida> GetBebidaByIdAsync(Guid id);
        Task<List<Bebida>> GetAllBebidaAsync();
        Task CreateBebidaAsync(Bebida bebida);
        Task UpdateBebidaAsync(Bebida bebida);
        Task DeleteBebidaAsync(Guid id);
    }
}
