using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(long id);
        Task AddAsync(Comentario entity);
        Task UpdateAsync(Comentario entity);
        Task DeleteAsync(Comentario entity);
    }
}
