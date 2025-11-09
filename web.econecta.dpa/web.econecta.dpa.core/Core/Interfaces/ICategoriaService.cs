using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaListDto>> GetCategoriasAsync();
        Task<CategoriaDetailDto?> GetCategoriaByIdAsync(long id);
        Task AddCategoriaAsync(CategoriaDto dto);
        Task UpdateCategoriaAsync(CategoriaDto dto);
        Task DeleteCategoriaAsync(long id);
    }
}
