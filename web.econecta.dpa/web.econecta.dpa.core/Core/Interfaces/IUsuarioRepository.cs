using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(long id);
        Task AddAsync(Usuario entity);
        Task UpdateAsync(Usuario entity);
        Task DeleteAsync(Usuario entity);

        // additional user-specific methods
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
