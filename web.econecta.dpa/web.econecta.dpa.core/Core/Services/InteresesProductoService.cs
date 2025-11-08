using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class InteresesProductoService : IInteresesProductoService
    {
        private readonly IInteresesProductoRepository _repo;
        public InteresesProductoService(IInteresesProductoRepository repo) => _repo = repo;

        public Task<List<InteresesProducto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<InteresesProducto?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(InteresesProducto entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(InteresesProducto entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(InteresesProducto entity) => _repo.DeleteAsync(entity);
    }
}
