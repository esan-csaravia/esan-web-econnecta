using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICalificacioneRepository
    {
        Task<List<Calificacione>> GetAllAsync();
        Task<Calificacione?> GetByIdAsync(long id);
        Task AddAsync(Calificacione entity);
        Task UpdateAsync(Calificacione entity);
        Task DeleteAsync(Calificacione entity);
    }
}
