using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

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
}
