using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IRestablecimientosContrasenaService
    {
        Task<List<RestablecimientosContrasena>> GetRestablecimientosAsync();
        Task<RestablecimientosContrasena?> GetRestablecimientoByIdAsync(long id);
        Task AddRestablecimientoAsync(RestablecimientosContrasena entity);
        Task UpdateRestablecimientoAsync(RestablecimientosContrasena entity);
        Task DeleteRestablecimientoAsync(RestablecimientosContrasena entity);

        // DTO methods
        Task<IEnumerable<RestablecimientosContrasenaDto>> GetRestablecimientosDtosAsync();
        Task<RestablecimientosContrasenaDto?> GetRestablecimientoDtoByIdAsync(long id);
    }
}
