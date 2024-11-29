using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCuenta_Propietario
{
    public interface ICuenta_PropietarioRepository
    {
        Task<Cuenta_Propietario> GetCuenta_PropietarioByIdAsync(Guid id);
        Task<List<Cuenta_Propietario>> GetAllCuenta_PropietarioAsync();
        Task CreateCuenta_PropietarioAsync(Cuenta_Propietario cuenta_Propietario);
        Task UpdateCuenta_PropietarioAsync(Cuenta_Propietario cuenta_Propietario);
        Task DeleteCuenta_PropietarioAsync(Guid id);
    }
}
