using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class NotificacioneService : INotificacioneService
    {
        private readonly INotificacioneRepository _repo;
        public NotificacioneService(INotificacioneRepository repo) => _repo = repo;

        public Task<List<Notificacione>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Notificacione?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Notificacione entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Notificacione entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Notificacione entity) => _repo.DeleteAsync(entity);
    }
}
