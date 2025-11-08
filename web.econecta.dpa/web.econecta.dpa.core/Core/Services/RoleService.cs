using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;
        public RoleService(IRoleRepository repo) => _repo = repo;

        public Task<List<Role>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Role?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Role entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Role entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Role entity) => _repo.DeleteAsync(entity);
    }
}
