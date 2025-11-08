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

        public Task<List<RestablecimientosContrasena>> GetAllAsync() => _repo.GetAllAsync();
        public Task<RestablecimientosContrasena?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(RestablecimientosContrasena entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(RestablecimientosContrasena entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(RestablecimientosContrasena entity) => _repo.DeleteAsync(entity);
    }
}
