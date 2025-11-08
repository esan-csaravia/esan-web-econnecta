using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICalificacioneService
    {
        Task<List<Calificacione>> GetAllAsync();
        Task<Calificacione?> GetByIdAsync(long id);
        Task AddAsync(Calificacione entity);
        Task UpdateAsync(Calificacione entity);
        Task DeleteAsync(Calificacione entity);
    }
}
