using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(long id);
        Task AddAsync(Role entity);
        Task UpdateAsync(Role entity);
        Task DeleteAsync(Role entity);
    }
}
