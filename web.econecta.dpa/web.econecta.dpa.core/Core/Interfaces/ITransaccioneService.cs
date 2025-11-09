using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ITransaccioneService
    {
        Task<List<Transaccione>> GetTransaccionesAsync();
        Task<Transaccione?> GetTransaccionByIdAsync(long id);
        Task AddTransaccionAsync(Transaccione entity);
        Task UpdateTransaccionAsync(Transaccione entity);
        Task DeleteTransaccionAsync(Transaccione entity);
    }
}
