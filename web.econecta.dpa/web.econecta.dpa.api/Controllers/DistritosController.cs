using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistritosController : ControllerBase
    {
        private readonly DistritoService _service;
        public DistritosController(DistritoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistritoDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(d => new DistritoDto { IdDistrito = d.IdDistrito, Nombre = d.Nombre }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistritoDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new DistritoDto { IdDistrito = ent.IdDistrito, Nombre = ent.Nombre };
        }

        [HttpPost]
        public async Task<ActionResult<DistritoDto>> Post([FromBody] DistritoDto dto)
        {
            var ent = new Distrito { Nombre = dto.Nombre };
            await _service.AddAsync(ent);
            dto.IdDistrito = ent.IdDistrito;
            return CreatedAtAction(nameof(Get), new { id = ent.IdDistrito }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] DistritoDto dto)
        {
            if (id != dto.IdDistrito) return BadRequest();
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            ent.Nombre = dto.Nombre;
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
