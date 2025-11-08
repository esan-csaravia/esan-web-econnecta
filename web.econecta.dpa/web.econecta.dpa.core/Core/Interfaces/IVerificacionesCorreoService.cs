using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IVerificacionesCorreoService
    {
        Task<List<VerificacionesCorreo>> GetAllAsync();
        Task<VerificacionesCorreo?> GetByIdAsync(long id);
        Task AddAsync(VerificacionesCorreo entity);
        Task UpdateAsync(VerificacionesCorreo entity);
        Task DeleteAsync(VerificacionesCorreo entity);
    }
}
