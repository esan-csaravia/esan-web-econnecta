using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly EcoConectaDBContext _context;

        public ProductosController(EcoConectaDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get([FromQuery] int? categoria, [FromQuery] int? distrito)
        {
            var query = _context.Productos.AsQueryable();
            if (categoria.HasValue) query = query.Where(p => p.IdCategoria == categoria.Value);
            if (distrito.HasValue) query = query.Where(p => p.IdDistrito == distrito.Value);
            return await query.Select(p => new ProductoDto
            {
                IdProducto = p.IdProducto,
                IdVendedor = p.IdVendedor,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                IdCategoria = p.IdCategoria,
                TipoPublicacion = p.TipoPublicacion,
                Condicion = p.Condicion,
                Precio = p.Precio,
                Cantidad = p.Cantidad,
                IdDistrito = p.IdDistrito,
                EstadoModeracion = p.EstadoModeracion,
                MotivoModeracion = p.MotivoModeracion,
                IdModerador = p.IdModerador,
                Activo = p.Activo,
                CreadoEn = p.CreadoEn,
                ActualizadoEn = p.ActualizadoEn
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> Get(long id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            return new ProductoDto
            {
                IdProducto = producto.IdProducto,
                IdVendedor = producto.IdVendedor,
                Titulo = producto.Titulo,
                Descripcion = producto.Descripcion,
                IdCategoria = producto.IdCategoria,
                TipoPublicacion = producto.TipoPublicacion,
                Condicion = producto.Condicion,
                Precio = producto.Precio,
                Cantidad = producto.Cantidad,
                IdDistrito = producto.IdDistrito,
                EstadoModeracion = producto.EstadoModeracion,
                MotivoModeracion = producto.MotivoModeracion,
                IdModerador = producto.IdModerador,
                Activo = producto.Activo,
                CreadoEn = producto.CreadoEn,
                ActualizadoEn = producto.ActualizadoEn
            };
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Post([FromBody] ProductoDto dto)
        {
            var producto = new Producto
            {
                IdVendedor = dto.IdVendedor,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                IdCategoria = dto.IdCategoria,
                TipoPublicacion = dto.TipoPublicacion,
                Condicion = dto.Condicion,
                Precio = dto.Precio,
                Cantidad = dto.Cantidad,
                IdDistrito = dto.IdDistrito,
                EstadoModeracion = dto.EstadoModeracion,
                MotivoModeracion = dto.MotivoModeracion,
                IdModerador = dto.IdModerador,
                Activo = dto.Activo,
                CreadoEn = dto.CreadoEn,
                ActualizadoEn = dto.ActualizadoEn
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            dto.IdProducto = producto.IdProducto;
            return CreatedAtAction(nameof(Get), new { id = producto.IdProducto }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ProductoDto dto)
        {
            if (id != dto.IdProducto) return BadRequest();

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            producto.Titulo = dto.Titulo;
            producto.Descripcion = dto.Descripcion;
            producto.IdCategoria = dto.IdCategoria;
            producto.TipoPublicacion = dto.TipoPublicacion;
            producto.Condicion = dto.Condicion;
            producto.Precio = dto.Precio;
            producto.Cantidad = dto.Cantidad;
            producto.IdDistrito = dto.IdDistrito;
            producto.EstadoModeracion = dto.EstadoModeracion;
            producto.MotivoModeracion = dto.MotivoModeracion;
            producto.IdModerador = dto.IdModerador;
            producto.Activo = dto.Activo;
            producto.ActualizadoEn = dto.ActualizadoEn;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Productos.AnyAsync(e => e.IdProducto == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
