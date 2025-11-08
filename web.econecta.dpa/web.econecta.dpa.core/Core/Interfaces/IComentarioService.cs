using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IComentarioService
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(long id);
        Task AddAsync(Comentario entity);
        Task UpdateAsync(Comentario entity);
        Task DeleteAsync(Comentario entity);
    }
}
