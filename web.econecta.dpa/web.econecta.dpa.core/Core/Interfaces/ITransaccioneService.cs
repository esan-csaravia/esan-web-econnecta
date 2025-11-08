using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ITransaccioneService
    {
        Task<List<Transaccione>> GetAllAsync();
        Task<Transaccione?> GetByIdAsync(long id);
        Task AddAsync(Transaccione entity);
        Task UpdateAsync(Transaccione entity);
        Task DeleteAsync(Transaccione entity);
    }
}
