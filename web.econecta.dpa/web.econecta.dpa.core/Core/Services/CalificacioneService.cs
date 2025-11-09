using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class CalificacioneService : ICalificacioneService
    {
        private readonly ICalificacioneRepository _repo;
        public CalificacioneService(ICalificacioneRepository repo) => _repo = repo;

        // existing
        public Task<List<Calificacione>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Calificacione?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Calificacione entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Calificacione entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Calificacione entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<Calificacione>> GetCalificacionesAsync() => GetAllAsync();
        public Task<Calificacione?> GetCalificacionByIdAsync(long id) => GetByIdAsync(id);
        public Task AddCalificacionAsync(Calificacione entity) => AddAsync(entity);
        public Task UpdateCalificacionAsync(Calificacione entity) => UpdateAsync(entity);
        public Task DeleteCalificacionAsync(Calificacione entity) => DeleteAsync(entity);
    }
}
