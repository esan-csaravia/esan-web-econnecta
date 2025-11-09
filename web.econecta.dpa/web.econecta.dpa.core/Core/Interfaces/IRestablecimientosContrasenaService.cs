using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IRestablecimientosContrasenaService
    {
        Task<List<RestablecimientosContrasena>> GetRestablecimientosAsync();
        Task<RestablecimientosContrasena?> GetRestablecimientoByIdAsync(long id);
        Task AddRestablecimientoAsync(RestablecimientosContrasena entity);
        Task UpdateRestablecimientoAsync(RestablecimientosContrasena entity);
        Task DeleteRestablecimientoAsync(RestablecimientosContrasena entity);
    }
}
