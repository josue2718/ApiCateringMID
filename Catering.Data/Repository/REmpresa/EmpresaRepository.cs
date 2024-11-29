using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repository.REmpresa
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _context;
        public EmpresaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Empresa> GetEmpresaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                throw new KeyNotFoundException($"Empresa con el ID {id} no fue encontrado.");
            }
            return empresa;
        }

        public async Task<List<Empresa>> GetAllEmpresaAsync()
        {
            try
            {
                return await _context.Empresas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Empresas.", ex);
            }
        }

        public async Task CreateEmpresaAsync(Empresa empresa)
        {
            if (empresa == null)
                throw new ArgumentNullException(nameof(empresa), "Empresa no puede ser nulo.");

            try
            {
                await _context.Empresas.AddAsync(empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Empresa en la base de datos.", ex);
            }
        }

        public async Task UpdateEmpresaAsync(Empresa empresa)
        {
            if (empresa == null)
                throw new ArgumentNullException(nameof(empresa), "Empresa no puede ser nulo.");

            try
            {
                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Empresa.", ex);
            }
        }

        public async Task DeleteEmpresaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var empresa = await GetEmpresaByIdAsync(id);
            if (empresa == null)
                throw new KeyNotFoundException($"Empresa con el ID {id} no existe.");

            try
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Empresa de la base de datos.", ex);
            }
        }
    }
}
