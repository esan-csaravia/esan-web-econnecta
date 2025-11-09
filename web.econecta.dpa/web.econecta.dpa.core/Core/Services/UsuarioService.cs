using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioService(IUsuarioRepository repo) => _repo = repo;

        // existing methods (kept for compatibility)
        public Task<List<Usuario>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Usuario?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task<Usuario?> GetByEmailAsync(string email) => _repo.GetByEmailAsync(email);
        public Task AddAsync(Usuario entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Usuario entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Usuario entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers to satisfy IUsuarioService
        public Task<List<Usuario>> GetUsuariosAsync() => GetAllAsync();
        public Task<Usuario?> GetUsuarioByIdAsync(long id) => GetByIdAsync(id);
        public Task<Usuario?> GetUsuarioByEmailAsync(string email) => GetByEmailAsync(email);
        public Task AddUsuarioAsync(Usuario entity) => AddAsync(entity);
        public Task UpdateUsuarioAsync(Usuario entity) => UpdateAsync(entity);
        public Task DeleteUsuarioAsync(Usuario entity) => DeleteAsync(entity);
    }
}
