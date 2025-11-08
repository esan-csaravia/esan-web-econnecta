using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IImagenesProductoService
    {
        Task<List<ImagenesProducto>> GetAllAsync();
        Task<ImagenesProducto?> GetByIdAsync(long id);
        Task AddAsync(ImagenesProducto entity);
        Task UpdateAsync(ImagenesProducto entity);
        Task DeleteAsync(ImagenesProducto entity);
    }
}
