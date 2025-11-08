using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface INotificacioneService
    {
        Task<List<Notificacione>> GetAllAsync();
        Task<Notificacione?> GetByIdAsync(long id);
        Task AddAsync(Notificacione entity);
        Task UpdateAsync(Notificacione entity);
        Task DeleteAsync(Notificacione entity);
    }
}
