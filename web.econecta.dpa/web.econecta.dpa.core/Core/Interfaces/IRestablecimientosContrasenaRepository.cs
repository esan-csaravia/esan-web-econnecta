using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IRestablecimientosContrasenaRepository
    {
        Task<List<RestablecimientosContrasena>> GetAllAsync();
        Task<RestablecimientosContrasena?> GetByIdAsync(long id);
        Task AddAsync(RestablecimientosContrasena entity);
        Task UpdateAsync(RestablecimientosContrasena entity);
        Task DeleteAsync(RestablecimientosContrasena entity);
    }
}
