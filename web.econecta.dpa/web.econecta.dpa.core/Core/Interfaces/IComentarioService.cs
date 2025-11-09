using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IComentarioService
    {
        Task<List<Comentario>> GetComentariosAsync();
        Task<Comentario?> GetComentarioByIdAsync(long id);
        Task AddComentarioAsync(Comentario entity);
        Task UpdateComentarioAsync(Comentario entity);
        Task DeleteComentarioAsync(Comentario entity);
    }
}
