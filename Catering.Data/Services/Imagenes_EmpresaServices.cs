using Cateing.Entity.Models;
using Catering.Data.Repository.RImagenes_Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Services
{
    public class Imagenes_EmpresaServices: IImagenes_EmpresaRepository
    {
        private readonly IImagenes_EmpresaRepository _repository;
        public Imagenes_EmpresaServices(IImagenes_EmpresaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Imagenes_Empresa> GetImagenes_EmpresaByIdAsync(Guid id)
        {
            return await _repository.GetImagenes_EmpresaByIdAsync(id);
        }

        public async Task<List<Imagenes_Empresa>> GetAllImagenes_EmpresaAsync()
        {
            return await _repository.GetAllImagenes_EmpresaAsync();
        }

        public async Task CreateImagenes_EmpresaAsync(Imagenes_Empresa imagenes_Empresa)
        {
            await _repository.CreateImagenes_EmpresaAsync(imagenes_Empresa);
        }

        public async Task UpdateImagenes_EmpresaAsync(Imagenes_Empresa imagenes_Empresa)
        {
            await _repository.UpdateImagenes_EmpresaAsync(imagenes_Empresa);
        }

        public async Task DeleteImagenes_EmpresaAsync(Guid id)
        {
            await _repository.DeleteImagenes_EmpresaAsync(id);
        }
    }
}
