using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _service;
        public CategoriasController(CategoriaService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(c => new CategoriaDto { IdCategoria = c.IdCategoria, Nombre = c.Nombre, IdPadre = c.IdPadre }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> Get(long id)
        {
            var c = await _service.GetByIdAsync(id);
            if (c == null) return NotFound();
            return new CategoriaDto { IdCategoria = c.IdCategoria, Nombre = c.Nombre, IdPadre = c.IdPadre };
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> Post([FromBody] CategoriaDto dto)
        {
            var ent = new Categoria { Nombre = dto.Nombre, IdPadre = dto.IdPadre };
            await _service.AddAsync(ent);
            dto.IdCategoria = ent.IdCategoria;
            return CreatedAtAction(nameof(Get), new { id = ent.IdCategoria }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CategoriaDto dto)
        {
            if (id != dto.IdCategoria) return BadRequest();
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            ent.Nombre = dto.Nombre;
            ent.IdPadre = dto.IdPadre;
            await _service.UpdateAsync(ent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            await _service.DeleteAsync(ent);
            return NoContent();
        }
    }
}
