using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<CategoriaListDto>> GetAllDtosAsync();
        Task<CategoriaDto?> GetDtoByIdAsync(long id);
        Task AddDtoAsync(CategoriaDto dto);
        Task UpdateDtoAsync(CategoriaDto dto);
        Task DeleteDtoAsync(long id);
    }
}
