using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Services
{
    public class ProductoService : IProductoService, IProductoRepository
    {
        private readonly IProductoRepository _repo;
        public ProductoService(IProductoRepository repo) => _repo = repo;

        // Entity-based methods
        public Task<List<Producto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Producto?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task<List<Producto>> SearchAsync(int? categoria, int? distrito) => _repo.SearchAsync(categoria, distrito);
        public Task AddAsync(Producto entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Producto entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Producto entity) => _repo.DeleteAsync(entity);

        // DTO-based methods (migradas desde ProductoAppService)
        public async Task<IEnumerable<ProductoDto>> GetProductosAsync() => await _repo.GetProductosAsync();

        public async Task<ProductoDto?> GetProductoByIdAsync(long id) => await _repo.GetProductoByIdAsync(id);

        public async Task AddProductoAsync(ProductoDto dto) => await _repo.AddProductoAsync(dto);

        public async Task UpdateProductoAsync(ProductoDto dto) => await _repo.UpdateProductoAsync(dto);

        public async Task DeleteProductoAsync(long id) => await _repo.DeleteProductoAsync(id);
    }
}
