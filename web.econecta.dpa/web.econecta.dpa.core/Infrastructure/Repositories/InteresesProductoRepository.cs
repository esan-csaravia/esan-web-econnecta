using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class InteresesProductoRepository : IInteresesProductoRepository
{
    private readonly EcoConectaDBContext _context;
    public InteresesProductoRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<InteresesProducto> Query() => _context.Set<InteresesProducto>();
    public Task<List<InteresesProducto>> GetAllAsync() => Query().ToListAsync();
    public Task<InteresesProducto?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(i => i.IdInteres == id);

    public async Task AddAsync(InteresesProducto entity) { _context.Set<InteresesProducto>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(InteresesProducto entity) { _context.Set<InteresesProducto>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(InteresesProducto entity) { _context.Set<InteresesProducto>().Remove(entity); await _context.SaveChangesAsync(); }
}
