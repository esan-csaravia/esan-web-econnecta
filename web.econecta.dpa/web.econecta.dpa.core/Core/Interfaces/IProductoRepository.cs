using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(long id);
        Task AddAsync(Producto entity);
        Task UpdateAsync(Producto entity);
        Task DeleteAsync(Producto entity);

        // product-specific query
        Task<List<Producto>> SearchAsync(int? categoria, int? distrito);

        Task<IEnumerable<ProductoDto>> GetProductosAsync();
        Task<ProductoDto?> GetProductoByIdAsync(long id);
        Task AddProductoAsync(ProductoDto dto);
        Task UpdateProductoAsync(ProductoDto dto);
        Task DeleteProductoAsync(long id);
    }
}
