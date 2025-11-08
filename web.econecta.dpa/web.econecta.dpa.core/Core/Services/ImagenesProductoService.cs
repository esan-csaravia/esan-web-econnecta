using System.Collections.Generic;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Core.Services
{
    public class ImagenesProductoService : IImagenesProductoService
    {
        private readonly IImagenesProductoRepository _repo;
        public ImagenesProductoService(IImagenesProductoRepository repo) => _repo = repo;

        public Task<List<ImagenesProducto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<ImagenesProducto?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task AddAsync(ImagenesProducto entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(ImagenesProducto entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(ImagenesProducto entity) => _repo.DeleteAsync(entity);
    }
}
