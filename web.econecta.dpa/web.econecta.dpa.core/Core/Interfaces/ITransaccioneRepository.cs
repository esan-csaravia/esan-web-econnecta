using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ITransaccioneRepository
    {
        Task<List<Transaccione>> GetAllAsync();
        Task<Transaccione?> GetByIdAsync(long id);
        Task AddAsync(Transaccione entity);
        Task UpdateAsync(Transaccione entity);
        Task DeleteAsync(Transaccione entity);
    }
}
