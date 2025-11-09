using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IInteresesProductoService
    {
        Task<List<InteresesProducto>> GetInteresesProductoAsync();
        Task<InteresesProducto?> GetInteresProductoByIdAsync(long id);
        Task AddInteresProductoAsync(InteresesProducto entity);
        Task UpdateInteresProductoAsync(InteresesProducto entity);
        Task DeleteInteresProductoAsync(InteresesProducto entity);
    }
}
