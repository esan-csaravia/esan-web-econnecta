using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class VerificacionesCorreoRepository : IVerificacionesCorreoRepository
{
    private readonly EcoConectaDBContext _context;
    public VerificacionesCorreoRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<VerificacionesCorreo> Query() => _context.Set<VerificacionesCorreo>();
    public Task<List<VerificacionesCorreo>> GetAllAsync() => Query().ToListAsync();
    public Task<VerificacionesCorreo?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(v => v.IdVerificacion == id);

    public async Task AddAsync(VerificacionesCorreo entity) { _context.Set<VerificacionesCorreo>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(VerificacionesCorreo entity) { _context.Set<VerificacionesCorreo>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(VerificacionesCorreo entity) { _context.Set<VerificacionesCorreo>().Remove(entity); await _context.SaveChangesAsync(); }
}
