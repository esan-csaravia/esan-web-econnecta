using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class DistritoService : IDistritoService
    {
        private readonly IDistritoRepository _repo;
        public DistritoService(IDistritoRepository repo) => _repo = repo;

        public Task<List<Distrito>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Distrito?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Distrito entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Distrito entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Distrito entity) => _repo.DeleteAsync(entity);
    }
}
