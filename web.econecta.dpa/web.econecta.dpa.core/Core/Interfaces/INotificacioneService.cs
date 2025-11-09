using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface INotificacioneService
    {
        Task<List<Notificacione>> GetNotificacionesAsync();
        Task<Notificacione?> GetNotificacioneByIdAsync(long id);
        Task AddNotificacioneAsync(Notificacione entity);
        Task UpdateNotificacioneAsync(Notificacione entity);
        Task DeleteNotificacioneAsync(Notificacione entity);

        // DTO methods
        Task<IEnumerable<NotificacioneDto>> GetNotificacionesDtosAsync();
        Task<NotificacioneDto?> GetNotificacioneDtoByIdAsync(long id);
    }
}
