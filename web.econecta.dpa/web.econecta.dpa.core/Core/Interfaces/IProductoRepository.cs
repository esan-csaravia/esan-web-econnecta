using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    //public interface IProductoRepository : IRepository<Producto>
    //{
    //    // additional product-specific methods
    //    Task<List<Producto>> SearchAsync(int? categoria, int? distrito);
    //}

    // Se mezcla aquí la interfaz del AppService para evitar un archivo separado.
    // Se usan nombres de método diferentes para evitar colisiones con los métodos que usan entidades.
    public interface IProductoRepository : IRepository<Producto>
    {
        // product-specific query
        Task<List<Producto>> SearchAsync(int? categoria, int? distrito);

        Task<IEnumerable<ProductoDto>> GetAllDtosAsync();
        Task<ProductoDto?> GetDtoByIdAsync(long id);
        Task AddDtoAsync(ProductoDto dto);
        Task UpdateDtoAsync(ProductoDto dto);
        Task DeleteDtoAsync(long id);
    }
}
