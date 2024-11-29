using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RCuenta_Cliente
{
    public interface ICuenta_ClienteRepository
    {
        Task<Cuenta_Cliente> GetCuenta_ClienteByIdAsync(Guid id);
        Task<List<Cuenta_Cliente>> GetAllCuenta_ClienteAsync();
        Task CreateCuenta_ClienteAsync(Cuenta_Cliente cuenta_Cliente);
        Task UpdateCuenta_ClienteAsync(Cuenta_Cliente cuenta_Cliente);
        Task DeleteCuenta_ClienteAsync(Guid id);
    }
}
