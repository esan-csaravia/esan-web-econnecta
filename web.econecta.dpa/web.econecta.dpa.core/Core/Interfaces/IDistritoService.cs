using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IDistritoService
    {
        Task<List<Distrito>> GetAllAsync();
        Task<Distrito?> GetByIdAsync(long id);
        Task AddAsync(Distrito entity);
        Task UpdateAsync(Distrito entity);
        Task DeleteAsync(Distrito entity);
    }
}
