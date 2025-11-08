using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        // additional product-specific methods
        Task<List<Producto>> SearchAsync(int? categoria, int? distrito);
    }
}
