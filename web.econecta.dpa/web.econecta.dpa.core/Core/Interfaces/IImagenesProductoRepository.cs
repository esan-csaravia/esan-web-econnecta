using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IImagenesProductoRepository
    {
        Task<List<ImagenesProducto>> GetAllAsync();
        Task<ImagenesProducto?> GetByIdAsync(long id);
        Task AddAsync(ImagenesProducto entity);
        Task UpdateAsync(ImagenesProducto entity);
        Task DeleteAsync(ImagenesProducto entity);
    }
}
