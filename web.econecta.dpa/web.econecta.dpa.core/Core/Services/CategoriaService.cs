using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repo;
        public CategoriaService(ICategoriaRepository repo) => _repo = repo;

        public Task<List<Categoria>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Categoria?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Categoria entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Categoria entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Categoria entity) => _repo.DeleteAsync(entity);
    }
}
