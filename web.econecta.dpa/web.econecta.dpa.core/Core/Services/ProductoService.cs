using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;
        public ProductoService(IProductoRepository repo) => _repo = repo;

        public Task<List<Producto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Producto?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task<List<Producto>> SearchAsync(int? categoria, int? distrito) => _repo.SearchAsync(categoria, distrito);
        public Task AddAsync(Producto entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Producto entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Producto entity) => _repo.DeleteAsync(entity);
    }
}
