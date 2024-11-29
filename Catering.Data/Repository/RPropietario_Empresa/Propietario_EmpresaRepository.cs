using Cateing.Entity.Models;
using Catering.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Data.Repository.RPropietario_Empresa
{
    public class Propietario_EmpresaRepository : IPropietario_EmpresaRepository
    {
        private readonly ApplicationDbContext _context;

        public Propietario_EmpresaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Propietario_Empresa> GetPropietario_EmpresaByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var propietarioEmpresa = await _context.Propietario_Empresas.FindAsync(id);
            if (propietarioEmpresa == null)
            {
                throw new KeyNotFoundException($"Propietario_Empresa con el ID {id} no fue encontrado.");
            }
            return propietarioEmpresa;
        }

        public async Task<List<Propietario_Empresa>> GetAllPropietario_EmpresaAsync()
        {
            try
            {
                return await _context.Propietario_Empresas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Propietario_Empresa.", ex);
            }
        }

        public async Task CreatePropietario_EmpresaAsync(Propietario_Empresa propietarioEmpresa)
        {
            if (propietarioEmpresa == null)
                throw new ArgumentNullException(nameof(propietarioEmpresa), "Propietario_Empresa no puede ser nulo.");

            try
            {
                await _context.Propietario_Empresas.AddAsync(propietarioEmpresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al crear Propietario_Empresa en la base de datos.", ex);
            }
        }

        public async Task UpdatePropietario_EmpresaAsync(Propietario_Empresa propietarioEmpresa)
        {
            if (propietarioEmpresa == null)
                throw new ArgumentNullException(nameof(propietarioEmpresa), "Propietario_Empresa no puede ser nulo.");

            try
            {
                _context.Propietario_Empresas.Update(propietarioEmpresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia al actualizar Propietario_Empresa.", ex);
            }
        }

        public async Task DeletePropietario_EmpresaAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

            var propietarioEmpresa = await GetPropietario_EmpresaByIdAsync(id);
            if (propietarioEmpresa == null)
                throw new KeyNotFoundException($"Propietario_Empresa con el ID {id} no existe.");

            try
            {
                _context.Propietario_Empresas.Remove(propietarioEmpresa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar Propietario_Empresa de la base de datos.", ex);
            }
        }
    }
}
