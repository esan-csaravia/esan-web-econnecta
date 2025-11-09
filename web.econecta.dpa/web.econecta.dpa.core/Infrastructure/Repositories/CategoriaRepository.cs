using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly EcoConectaDBContext _context;
    public CategoriaRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Categoria> Query() => _context.Set<Categoria>();
    public Task<List<Categoria>> GetAllAsync() => Query().ToListAsync();
    public Task<Categoria?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(c => c.IdCategoria == id);

    public async Task AddAsync(Categoria entity) { _context.Set<Categoria>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Categoria entity) { _context.Set<Categoria>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Categoria entity) { _context.Set<Categoria>().Remove(entity); await _context.SaveChangesAsync(); }

    // DTO methods
    public async Task<IEnumerable<CategoriaListDto>> GetAllDtosAsync()
    {
        var list = await Query().ToListAsync();
        return list.Select(c => new CategoriaListDto { IdCategoria = c.IdCategoria, Nombre = c.Nombre }).ToList();
    }

    public async Task<CategoriaDto?> GetDtoByIdAsync(long id)
    {
        var c = await GetByIdAsync(id);
        return c == null ? null : MapToDto(c);
    }

    public async Task AddDtoAsync(CategoriaDto dto)
    {
        var entity = MapToEntity(dto);
        _context.Set<Categoria>().Add(entity);
        await _context.SaveChangesAsync();
        dto.IdCategoria = entity.IdCategoria;
    }

    public async Task UpdateDtoAsync(CategoriaDto dto)
    {
        var entity = MapToEntity(dto);
        _context.Set<Categoria>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDtoAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return;
        _context.Set<Categoria>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    private static CategoriaDto MapToDto(Categoria c) => new CategoriaDto { IdCategoria = c.IdCategoria, Nombre = c.Nombre, IdPadre = c.IdPadre };
    private static Categoria MapToEntity(CategoriaDto dto) => new Categoria { IdCategoria = dto.IdCategoria, Nombre = dto.Nombre, IdPadre = dto.IdPadre };
}
