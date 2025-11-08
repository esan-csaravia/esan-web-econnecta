using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(long id);
        Task<List<Producto>> SearchAsync(int? categoria, int? distrito);
        Task AddAsync(Producto entity);
        Task UpdateAsync(Producto entity);
        Task DeleteAsync(Producto entity);
    }
}
