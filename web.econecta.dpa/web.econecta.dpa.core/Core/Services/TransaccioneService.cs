using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

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

        // DTO methods
        public async Task<IEnumerable<TransaccioneDto>> GetTransaccionesDtosAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(t => new TransaccioneDto
            {
                IdTransaccion = t.IdTransaccion,
                Tipo = t.Tipo,
                Productos = new List<ProductoDto>
                {
                    new ProductoDto
                    {
                        IdProducto = t.IdProducto,
                        //IdVendedor = 0,
                       // Vendedor = null,
                        Titulo = string.Empty,
                        Descripcion = string.Empty
                       // IdCategoria = 0,
                       
                    }
                },
                Vendedores = new List<UsuarioListDto>
                {
                    new UsuarioListDto { IdUsuario = t.IdVendedor, NombreCompleto = string.Empty, Correo = string.Empty }
                },
                Compradores = new List<UsuarioListDto>
                {
                    new UsuarioListDto { IdUsuario = t.IdComprador, NombreCompleto = string.Empty, Correo = string.Empty }
                },
                Cantidad = t.Cantidad,
                PrecioUnitario = t.PrecioUnitario,
                MontoTotal = t.MontoTotal,
                Estado = t.Estado,
                CreadoEn = t.CreadoEn,
                CompletadoEn = t.CompletadoEn
            });
        }

        public async Task<TransaccioneDto?> GetTransaccionDtoByIdAsync(long id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;
            return new TransaccioneDto
            {
                IdTransaccion = t.IdTransaccion,
                Tipo = t.Tipo,
                Productos = new List<ProductoDto>
                {
                    new ProductoDto
                    {
                        IdProducto = t.IdProducto,
                        IdVendedor = 0,
                        Vendedor = null,
                        Titulo = string.Empty,
                        Descripcion = string.Empty,
                        IdCategoria = 0,
                        Categoria = null,
                        TipoPublicacion = string.Empty,
                        Condicion = string.Empty,
                        Precio = null,
                        Cantidad = 0,
                        IdDistrito = null,
                        Distrito = null,
                        EstadoModeracion = string.Empty,
                        MotivoModeracion = null,
                        IdModerador = null,
                        Activo = false,
                        CreadoEn = t.CreadoEn,
                        ActualizadoEn = t.CompletadoEn
                    }
                },
                Vendedores = new List<UsuarioListDto>
                {
                    new UsuarioListDto { IdUsuario = t.IdVendedor, NombreCompleto = string.Empty, Correo = string.Empty }
                },
                Compradores = new List<UsuarioListDto>
                {
                    new UsuarioListDto { IdUsuario = t.IdComprador, NombreCompleto = string.Empty, Correo = string.Empty }
                },
                Cantidad = t.Cantidad,
                PrecioUnitario = t.PrecioUnitario,
                MontoTotal = t.MontoTotal,
                Estado = t.Estado,
                CreadoEn = t.CreadoEn,
                CompletadoEn = t.CompletadoEn
            };
        }
    }
}
