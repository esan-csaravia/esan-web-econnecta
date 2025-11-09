using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesAsync();
        Task<Role?> GetRoleByIdAsync(long id);
        Task AddRoleAsync(Role entity);
        Task UpdateRoleAsync(Role entity);
        Task DeleteRoleAsync(Role entity);
    }
}
