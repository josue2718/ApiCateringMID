using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.REmpresa
{
    public interface IEmpresaRepository
    {
        Task<Empresa> GetEmpresaByIdAsync(Guid id);
        Task<List<Empresa>> GetAllEmpresaAsync();
        Task CreateEmpresaAsync(Empresa empresa);
        Task UpdateEmpresaAsync(Empresa empresa);
        Task DeleteEmpresaAsync(Guid id);
    }
}
