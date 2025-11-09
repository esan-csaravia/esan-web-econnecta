using web.econecta.dpa.core.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(long id);
        Task AddAsync(Categoria entity);
        Task UpdateAsync(Categoria entity);
        Task DeleteAsync(Categoria entity);

        Task<IEnumerable<CategoriaListDto>> GetAllDtosAsync();
        Task<CategoriaDto?> GetDtoByIdAsync(long id);
        Task AddDtoAsync(CategoriaDto dto);
        Task UpdateDtoAsync(CategoriaDto dto);
        Task DeleteDtoAsync(long id);
    }
}
