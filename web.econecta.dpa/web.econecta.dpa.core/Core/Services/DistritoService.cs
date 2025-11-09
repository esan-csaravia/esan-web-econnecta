using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Services
{
    public class DistritoService : IDistritoService
    {
        private readonly IDistritoRepository _repo;
        public DistritoService(IDistritoRepository repo) => _repo = repo;

        // existing
        public Task<List<Distrito>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Distrito?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Distrito entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Distrito entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Distrito entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<Distrito>> GetDistritosAsync() => GetAllAsync();
        public Task<Distrito?> GetDistritoByIdAsync(long id) => GetByIdAsync(id);
        public Task AddDistritoAsync(Distrito entity) => AddAsync(entity);
        public Task UpdateDistritoAsync(Distrito entity) => UpdateAsync(entity);
        public Task DeleteDistritoAsync(Distrito entity) => DeleteAsync(entity);

        // DTO methods
        public async Task<IEnumerable<DistritoDto>> GetDistritosDtosAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(d => new DistritoDto { IdDistrito = d.IdDistrito, Nombre = d.Nombre });
        }

        public async Task<DistritoDto?> GetDistritoDtoByIdAsync(long id)
        {
            var d = await _repo.GetByIdAsync(id);
            if (d == null) return null;
            return new DistritoDto { IdDistrito = d.IdDistrito, Nombre = d.Nombre };
        }
    }
}
