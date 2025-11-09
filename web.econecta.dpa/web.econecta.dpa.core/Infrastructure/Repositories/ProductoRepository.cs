using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly EcoConectaDBContext _context;
    public ProductoRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Producto> Query() => _context.Set<Producto>();

    public Task<List<Producto>> GetAllAsync() => Query().ToListAsync();

    public Task<Producto?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(p => p.IdProducto == id);

    public async Task AddAsync(Producto entity)
    {
        _context.Productos.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Producto entity)
    {
        _context.Productos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Producto entity)
    {
        _context.Productos.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<List<Producto>> SearchAsync(int? categoria, int? distrito)
    {
        var query = Query();
        if (categoria.HasValue) query = query.Where(p => p.IdCategoria == categoria.Value);
        if (distrito.HasValue) query = query.Where(p => p.IdDistrito == distrito.Value);
        return query.ToListAsync();
    }

    // DTO methods required by IProductoRepository
    public async Task<IEnumerable<ProductoDto>> GetAllDtosAsync()
    {
        // Project products including category list DTO
        var query = from p in Query()
                    join c in _context.Categorias on p.IdCategoria equals c.IdCategoria into pc
                    from c in pc.DefaultIfEmpty()
                    join u in _context.Usuarios on p.IdVendedor equals u.IdUsuario into pu
                    from u in pu.DefaultIfEmpty()
                    join d in _context.Distritos on p.IdDistrito equals d.IdDistrito into pd
                    from d in pd.DefaultIfEmpty()
                    select new ProductoDto
                    {
                        IdProducto = p.IdProducto,
                        //IdVendedor = p.IdVendedor,
                        Titulo = p.Titulo,
                        Descripcion = p.Descripcion,
                        //IdCategoria = p.IdCategoria,
                        Categoria = c == null ? null : new CategoriaListDto { IdCategoria = c.IdCategoria, Nombre = c.Nombre },
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
                        ActualizadoEn = p.ActualizadoEn,
                        // include vendedor and distrito DTOs
                        Vendedor = u == null ? null : new UsuarioListDto { IdUsuario = u.IdUsuario, NombreCompleto = u.NombreCompleto, Correo = u.Correo },
                        Distrito = d == null ? null : new DistritoListDto { IdDistrito = d.IdDistrito, Nombre = d.Nombre }
                    };
        return await query.ToListAsync();
    }

    public async Task<ProductoDto?> GetDtoByIdAsync(long id)
    {
        var query = from p in Query()
                    where p.IdProducto == id
                    join c in _context.Categorias on p.IdCategoria equals c.IdCategoria into pc
                    from c in pc.DefaultIfEmpty()
                    join u in _context.Usuarios on p.IdVendedor equals u.IdUsuario into pu
                    from u in pu.DefaultIfEmpty()
                    join d in _context.Distritos on p.IdDistrito equals d.IdDistrito into pd
                    from d in pd.DefaultIfEmpty()
                    select new ProductoDto
                    {
                        IdProducto = p.IdProducto,
                        //IdVendedor = p.IdVendedor,
                        Titulo = p.Titulo,
                        Descripcion = p.Descripcion,
                        //IdCategoria = p.IdCategoria,
                        Categoria = c == null ? null : new CategoriaListDto { IdCategoria = c.IdCategoria, Nombre = c.Nombre },
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
                        ActualizadoEn = p.ActualizadoEn,
                        Vendedor = u == null ? null : new UsuarioListDto { IdUsuario = u.IdUsuario, NombreCompleto = u.NombreCompleto, Correo = u.Correo },
                        Distrito = d == null ? null : new DistritoListDto { IdDistrito = d.IdDistrito, Nombre = d.Nombre }
                    };
        return await query.FirstOrDefaultAsync();
    }

    public async Task AddDtoAsync(ProductoDto dto)
    {
        var entity = MapToEntity(dto);
        _context.Productos.Add(entity);
        await _context.SaveChangesAsync();
        dto.IdProducto = entity.IdProducto;
    }

    public async Task UpdateDtoAsync(ProductoDto dto)
    {
        var entity = MapToEntity(dto);
        _context.Productos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDtoAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return;
        _context.Productos.Remove(entity);
        await _context.SaveChangesAsync();
    }

    // Mapping helpers
    private static ProductoDto MapToDto(Producto p) => new ProductoDto
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

    private static Producto MapToEntity(ProductoDto dto) => new Producto
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
}
