using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IProductoService
    {
        // Entity-based methods
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(long id);
        Task<List<Producto>> SearchAsync(int? categoria, int? distrito);
        Task AddAsync(Producto entity);
        Task UpdateAsync(Producto entity);
        Task DeleteAsync(Producto entity);

        // DTO-based methods for controllers
        Task<IEnumerable<ProductoDto>> GetProductosAsync();
        Task<ProductoDto?> GetProductoByIdAsync(long id);
        Task AddProductoAsync(ProductoDto dto);
        Task UpdateProductoAsync(ProductoDto dto);
        Task DeleteProductoAsync(long id);
    }
}
