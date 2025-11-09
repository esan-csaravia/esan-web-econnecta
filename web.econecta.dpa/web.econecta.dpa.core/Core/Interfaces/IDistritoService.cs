using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IDistritoService
    {
        Task<List<Distrito>> GetDistritosAsync();
        Task<Distrito?> GetDistritoByIdAsync(long id);
        Task AddDistritoAsync(Distrito entity);
        Task UpdateDistritoAsync(Distrito entity);
        Task DeleteDistritoAsync(Distrito entity);
    }
}
