using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Core.Services
{
    public class ProductoService : IProductoService, IProductoRepository
    {
        private readonly IProductoRepository _repo;
        public ProductoService(IProductoRepository repo) => _repo = repo;

        // Entity-based methods
        public Task<List<Producto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Producto?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
        public Task<List<Producto>> SearchAsync(int? categoria, int? distrito) => _repo.SearchAsync(categoria, distrito);
        public Task AddAsync(Producto entity) => _repo.AddAsync(entity);
        public Task UpdateAsync(Producto entity) => _repo.UpdateAsync(entity);
        public Task DeleteAsync(Producto entity) => _repo.DeleteAsync(entity);

        // DTO-based methods (migradas desde ProductoAppService)
        public async Task<IEnumerable<ProductoDto>> GetAllDtosAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(p => new ProductoDto
            {
                IdProducto = p.IdProducto,
                //IdVendedor = p.IdVendedor,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                //IdCategoria = p.IdCategoria,
                TipoPublicacion = p.TipoPublicacion,
                Condicion = p.Condicion,
                Precio = p.Precio,
                Cantidad = p.Cantidad,
                //IdDistrito = p.IdDistrito,
                EstadoModeracion = p.EstadoModeracion,
                MotivoModeracion = p.MotivoModeracion,
                IdModerador = p.IdModerador,
                Activo = p.Activo,
                CreadoEn = p.CreadoEn,
                ActualizadoEn = p.ActualizadoEn
            }).ToList();
        }

        public async Task<ProductoDto?> GetDtoByIdAsync(long id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new ProductoDto
            {
                IdProducto = p.IdProducto,
                //IdVendedor = p.IdVendedor,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                //IdCategoria = p.IdCategoria,
                TipoPublicacion = p.TipoPublicacion,
                Condicion = p.Condicion,
                Precio = p.Precio,
                Cantidad = p.Cantidad,
                //IdDistrito = p.IdDistrito,
                EstadoModeracion = p.EstadoModeracion,
                MotivoModeracion = p.MotivoModeracion,
                IdModerador = p.IdModerador,
                Activo = p.Activo,
                CreadoEn = p.CreadoEn,
                ActualizadoEn = p.ActualizadoEn
            };
        }

        public async Task AddDtoAsync(ProductoDto dto)
        {
            var entity = new Producto
            {
                //IdVendedor = dto.IdVendedor,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                //IdCategoria = dto.IdCategoria,
                TipoPublicacion = dto.TipoPublicacion,
                Condicion = dto.Condicion,
                Precio = dto.Precio,
                Cantidad = dto.Cantidad,
                //IdDistrito = dto.IdDistrito,
                EstadoModeracion = dto.EstadoModeracion,
                MotivoModeracion = dto.MotivoModeracion,
                IdModerador = dto.IdModerador,
                Activo = dto.Activo,
                CreadoEn = dto.CreadoEn,
                ActualizadoEn = dto.ActualizadoEn
            };
            await _repo.AddAsync(entity);
            dto.IdProducto = entity.IdProducto;
        }

        public async Task UpdateDtoAsync(ProductoDto dto)
        {
            var entity = new Producto
            {
                IdProducto = dto.IdProducto,
                //IdVendedor = dto.IdVendedor,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                //IdCategoria = dto.IdCategoria,
                TipoPublicacion = dto.TipoPublicacion,
                Condicion = dto.Condicion,
                Precio = dto.Precio,
                Cantidad = dto.Cantidad,
                //IdDistrito = dto.IdDistrito,
                EstadoModeracion = dto.EstadoModeracion,
                MotivoModeracion = dto.MotivoModeracion,
                IdModerador = dto.IdModerador,
                Activo = dto.Activo,
                CreadoEn = dto.CreadoEn,
                ActualizadoEn = dto.ActualizadoEn
            };
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteDtoAsync(long id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return;
            await _repo.DeleteAsync(entity);
        }
    }
}
