using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RPropietario_Empresa
{
    public interface IPropietario_EmpresaRepository
    {
        Task<Propietario_Empresa> GetPropietario_EmpresaByIdAsync(Guid id);
        Task<List<Propietario_Empresa>> GetAllPropietario_EmpresaAsync();
        Task CreatePropietario_EmpresaAsync(Propietario_Empresa propietario_Empresa);
        Task UpdatePropietario_EmpresaAsync(Propietario_Empresa propietario_Empresa);
        Task DeletePropietario_EmpresaAsync(Guid id);
    }
}
