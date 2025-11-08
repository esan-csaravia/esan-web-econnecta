using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IRestablecimientosContrasenaService
    {
        Task<List<RestablecimientosContrasena>> GetAllAsync();
        Task<RestablecimientosContrasena?> GetByIdAsync(long id);
        Task AddAsync(RestablecimientosContrasena entity);
        Task UpdateAsync(RestablecimientosContrasena entity);
        Task DeleteAsync(RestablecimientosContrasena entity);
    }
}
