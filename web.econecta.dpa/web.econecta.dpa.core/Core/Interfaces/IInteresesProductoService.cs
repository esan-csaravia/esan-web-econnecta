using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IInteresesProductoService
    {
        Task<List<InteresesProducto>> GetAllAsync();
        Task<InteresesProducto?> GetByIdAsync(long id);
        Task AddAsync(InteresesProducto entity);
        Task UpdateAsync(InteresesProducto entity);
        Task DeleteAsync(InteresesProducto entity);
    }
}
