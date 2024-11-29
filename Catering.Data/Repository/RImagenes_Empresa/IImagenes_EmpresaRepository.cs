using Cateing.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RImagenes_Empresa
{
    public interface IImagenes_EmpresaRepository
    {
        Task<Imagenes_Empresa> GetImagenes_EmpresaByIdAsync(Guid id);
        Task<List<Imagenes_Empresa>> GetAllImagenes_EmpresaAsync();
        Task CreateImagenes_EmpresaAsync(Imagenes_Empresa imagenes_Empresa);
        Task UpdateImagenes_EmpresaAsync(Imagenes_Empresa imagenes_Empresa);
        Task DeleteImagenes_EmpresaAsync(Guid id);
    }
}
