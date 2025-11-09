using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Services
{
    public class NotificacioneService : INotificacioneService
    {
        private readonly INotificacioneRepository _repo;
        public NotificacioneService(INotificacioneRepository repo) => _repo = repo;

        // existing
        public Task<List<Notificacione>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Notificacione?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Notificacione entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Notificacione entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Notificacione entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<Notificacione>> GetNotificacionesAsync() => GetAllAsync();
        public Task<Notificacione?> GetNotificacioneByIdAsync(long id) => GetByIdAsync(id);
        public Task AddNotificacioneAsync(Notificacione entity) => AddAsync(entity);
        public Task UpdateNotificacioneAsync(Notificacione entity) => UpdateAsync(entity);
        public Task DeleteNotificacioneAsync(Notificacione entity) => DeleteAsync(entity);

        // DTO methods
        public async Task<IEnumerable<NotificacioneDto>> GetNotificacionesDtosAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(n => new NotificacioneDto
            {
                IdNotificacion = n.IdNotificacion,
                IdDestinatario = n.IdDestinatario,
                Tipo = n.Tipo,
                Titulo = n.Titulo,
                Cuerpo = n.Cuerpo,
                Canal = n.Canal,
                IdProductoRelacionado = n.IdProductoRelacionado,
                IdTransaccionRelacionada = n.IdTransaccionRelacionada,
                LeidoEn = n.LeidoEn,
                CreadoEn = n.CreadoEn
            });
        }

        public async Task<NotificacioneDto?> GetNotificacioneDtoByIdAsync(long id)
        {
            var n = await _repo.GetByIdAsync(id);
            if (n == null) return null;
            return new NotificacioneDto
            {
                IdNotificacion = n.IdNotificacion,
                IdDestinatario = n.IdDestinatario,
                Tipo = n.Tipo,
                Titulo = n.Titulo,
                Cuerpo = n.Cuerpo,
                Canal = n.Canal,
                IdProductoRelacionado = n.IdProductoRelacionado,
                IdTransaccionRelacionada = n.IdTransaccionRelacionada,
                LeidoEn = n.LeidoEn,
                CreadoEn = n.CreadoEn
            };
        }
    }
}
