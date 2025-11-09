using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repo;
        public CategoriaService(ICategoriaRepository repo) => _repo = repo;

        public async Task<IEnumerable<CategoriaListDto>> GetCategoriasAsync()
        {
            var categories = await _repo.GetAllAsync();
            var categoriesDTO = new List<CategoriaListDto>();

            foreach (var category in categories)
            {
                var categoryDTO = new CategoriaListDto
                {
                    IdCategoria = category.IdCategoria,
                    Nombre = category.Nombre
                };

                categoriesDTO.Add(categoryDTO);
            }

            return categoriesDTO;
        }

        public async Task<CategoriaDetailDto?> GetCategoriaByIdAsync(long id)
        {
            var dto = await _repo.GetDtoByIdAsync(id);
            return dto == null ? null : new CategoriaDetailDto { IdCategoria = dto.IdCategoria, Nombre = dto.Nombre, IdPadre = dto.IdPadre };
        }

        public Task AddCategoriaAsync(CategoriaDto dto) => _repo.AddDtoAsync(dto);

        public Task UpdateCategoriaAsync(CategoriaDto dto) => _repo.UpdateDtoAsync(dto);

        public Task DeleteCategoriaAsync(long id) => _repo.DeleteDtoAsync(id);
    }
}
