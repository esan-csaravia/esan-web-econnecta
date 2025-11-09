using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class RestablecimientosContrasenaService : IRestablecimientosContrasenaService
    {
        private readonly IRestablecimientosContrasenaRepository _repo;
        public RestablecimientosContrasenaService(IRestablecimientosContrasenaRepository repo) => _repo = repo;

        // existing
        public Task<List<RestablecimientosContrasena>> GetAllAsync() => _repo.GetAllAsync();
        public Task<RestablecimientosContrasena?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(RestablecimientosContrasena entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(RestablecimientosContrasena entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(RestablecimientosContrasena entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<RestablecimientosContrasena>> GetRestablecimientosAsync() => GetAllAsync();
        public Task<RestablecimientosContrasena?> GetRestablecimientoByIdAsync(long id) => GetByIdAsync(id);
        public Task AddRestablecimientoAsync(RestablecimientosContrasena entity) => AddAsync(entity);
        public Task UpdateRestablecimientoAsync(RestablecimientosContrasena entity) => UpdateAsync(entity);
        public Task DeleteRestablecimientoAsync(RestablecimientosContrasena entity) => DeleteAsync(entity);
    }
}
