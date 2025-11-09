using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario?> GetUsuarioByIdAsync(long id);
        Task<Usuario?> GetUsuarioByEmailAsync(string email);
        Task AddUsuarioAsync(Usuario entity);
        Task UpdateUsuarioAsync(Usuario entity);
        Task DeleteUsuarioAsync(Usuario entity);
    }
}
