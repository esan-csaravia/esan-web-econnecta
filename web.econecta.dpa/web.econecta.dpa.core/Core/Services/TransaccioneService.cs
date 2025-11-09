using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class TransaccioneService : ITransaccioneService
    {
        private readonly ITransaccioneRepository _repo;
        public TransaccioneService(ITransaccioneRepository repo) => _repo = repo;

        // existing
        public Task<List<Transaccione>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Transaccione?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Transaccione entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Transaccione entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Transaccione entity) => _repo.DeleteAsync(entity);

        // descriptive wrappers
        public Task<List<Transaccione>> GetTransaccionesAsync() => GetAllAsync();
        public Task<Transaccione?> GetTransaccionByIdAsync(long id) => GetByIdAsync(id);
        public Task AddTransaccionAsync(Transaccione entity) => AddAsync(entity);
        public Task UpdateTransaccionAsync(Transaccione entity) => UpdateAsync(entity);
        public Task DeleteTransaccionAsync(Transaccione entity) => DeleteAsync(entity);
    }
}
