using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IDistritoRepository
    {
        Task<List<Distrito>> GetAllAsync();
        Task<Distrito?> GetByIdAsync(long id);
        Task AddAsync(Distrito entity);
        Task UpdateAsync(Distrito entity);
        Task DeleteAsync(Distrito entity);
    }
}
