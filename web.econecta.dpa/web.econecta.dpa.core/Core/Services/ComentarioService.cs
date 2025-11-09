using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _repo;
        public ComentarioService(IComentarioRepository repo) => _repo = repo;

        // existing
        public Task<List<Comentario>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Comentario?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Comentario entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Comentario entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Comentario entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<Comentario>> GetComentariosAsync() => GetAllAsync();
        public Task<Comentario?> GetComentarioByIdAsync(long id) => GetByIdAsync(id);
        public Task AddComentarioAsync(Comentario entity) => AddAsync(entity);
        public Task UpdateComentarioAsync(Comentario entity) => UpdateAsync(entity);
        public Task DeleteComentarioAsync(Comentario entity) => DeleteAsync(entity);
    }
}
