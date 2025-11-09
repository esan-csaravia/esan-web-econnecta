using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class VerificacionesCorreoService : IVerificacionesCorreoService
    {
        private readonly IVerificacionesCorreoRepository _repo;
        public VerificacionesCorreoService(IVerificacionesCorreoRepository repo) => _repo = repo;

        // existing
        public Task<List<VerificacionesCorreo>> GetAllAsync() => _repo.GetAllAsync();
        public Task<VerificacionesCorreo?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(VerificacionesCorreo entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(VerificacionesCorreo entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(VerificacionesCorreo entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<VerificacionesCorreo>> GetVerificacionesCorreoAsync() => GetAllAsync();
        public Task<VerificacionesCorreo?> GetVerificacionCorreoByIdAsync(long id) => GetByIdAsync(id);
        public Task AddVerificacionCorreoAsync(VerificacionesCorreo entity) => AddAsync(entity);
        public Task UpdateVerificacionCorreoAsync(VerificacionesCorreo entity) => UpdateAsync(entity);
        public Task DeleteVerificacionCorreoAsync(VerificacionesCorreo entity) => DeleteAsync(entity);
    }
}
