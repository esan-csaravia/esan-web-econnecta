using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IVerificacionesCorreoService
    {
        Task<List<VerificacionesCorreo>> GetVerificacionesCorreoAsync();
        Task<VerificacionesCorreo?> GetVerificacionCorreoByIdAsync(long id);
        Task AddVerificacionCorreoAsync(VerificacionesCorreo entity);
        Task UpdateVerificacionCorreoAsync(VerificacionesCorreo entity);
        Task DeleteVerificacionCorreoAsync(VerificacionesCorreo entity);
    }
}
