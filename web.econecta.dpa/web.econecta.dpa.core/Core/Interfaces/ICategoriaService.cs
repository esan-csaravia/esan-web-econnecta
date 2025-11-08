using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(long id);
        Task AddAsync(Categoria entity);
        Task UpdateAsync(Categoria entity);
        Task DeleteAsync(Categoria entity);
    }
}
