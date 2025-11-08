using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class ImagenesProductoRepository : IImagenesProductoRepository
{
    private readonly EcoConectaDBContext _context;
    public ImagenesProductoRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<ImagenesProducto> Query() => _context.Set<ImagenesProducto>();
    public Task<List<ImagenesProducto>> GetAllAsync() => Query().ToListAsync();
    public Task<ImagenesProducto?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(i => i.IdImagen == id);

    public async Task AddAsync(ImagenesProducto entity) { _context.Set<ImagenesProducto>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(ImagenesProducto entity) { _context.Set<ImagenesProducto>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(ImagenesProducto entity) { _context.Set<ImagenesProducto>().Remove(entity); await _context.SaveChangesAsync(); }
}
