using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface INotificacioneRepository
    {
        Task<List<Notificacione>> GetAllAsync();
        Task<Notificacione?> GetByIdAsync(long id);
        Task AddAsync(Notificacione entity);
        Task UpdateAsync(Notificacione entity);
        Task DeleteAsync(Notificacione entity);
    }
}
