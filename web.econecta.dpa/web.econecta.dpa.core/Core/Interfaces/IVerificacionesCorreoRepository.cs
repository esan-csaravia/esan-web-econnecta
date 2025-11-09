using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface IVerificacionesCorreoRepository
    {
        Task<List<VerificacionesCorreo>> GetAllAsync();
        Task<VerificacionesCorreo?> GetByIdAsync(long id);
        Task AddAsync(VerificacionesCorreo entity);
        Task UpdateAsync(VerificacionesCorreo entity);
        Task DeleteAsync(VerificacionesCorreo entity);
    }
}
