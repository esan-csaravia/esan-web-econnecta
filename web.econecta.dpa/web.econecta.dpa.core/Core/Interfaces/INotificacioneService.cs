using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface INotificacioneService
    {
        Task<List<Notificacione>> GetNotificacionesAsync();
        Task<Notificacione?> GetNotificacioneByIdAsync(long id);
        Task AddNotificacioneAsync(Notificacione entity);
        Task UpdateNotificacioneAsync(Notificacione entity);
        Task DeleteNotificacioneAsync(Notificacione entity);
    }
}
