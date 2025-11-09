using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IInteresesProductoRepository
    {
        Task<List<InteresesProducto>> GetAllAsync();
        Task<InteresesProducto?> GetByIdAsync(long id);
        Task AddAsync(InteresesProducto entity);
        Task UpdateAsync(InteresesProducto entity);
        Task DeleteAsync(InteresesProducto entity);
    }
}
