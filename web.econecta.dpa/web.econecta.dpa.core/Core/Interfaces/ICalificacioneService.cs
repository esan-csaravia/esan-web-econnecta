using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICalificacioneService
    {
        Task<List<Calificacione>> GetCalificacionesAsync();
        Task<Calificacione?> GetCalificacionByIdAsync(long id);
        Task AddCalificacionAsync(Calificacione entity);
        Task UpdateCalificacionAsync(Calificacione entity);
        Task DeleteCalificacionAsync(Calificacione entity);
    }
}
