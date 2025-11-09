using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistritosController : ControllerBase
    {
        private readonly IDistritoService _service;
        public DistritosController(IDistritoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistritoDto>>> Get()
        {
            var items = await _service.GetDistritosAsync();
            return items.Select(d => new DistritoDto { IdDistrito = d.IdDistrito, Nombre = d.Nombre }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistritoDto>> Get(long id)
        {
            var ent = await _service.GetDistritoByIdAsync(id);
            if (ent == null) return NotFound();
            return new DistritoDto { IdDistrito = ent.IdDistrito, Nombre = ent.Nombre };
        }

        [HttpPost]
        public async Task<ActionResult<DistritoDto>> Post([FromBody] DistritoDto dto)
        {
            var ent = new Distrito { Nombre = dto.Nombre };
            await _service.AddDistritoAsync(ent);
            dto.IdDistrito = ent.IdDistrito;
            return CreatedAtAction(nameof(Get), new { id = ent.IdDistrito }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] DistritoDto dto)
        {
            if (id != dto.IdDistrito) return BadRequest();
            var ent = await _service.GetDistritoByIdAsync(id);
            if (ent == null) return NotFound();
            ent.Nombre = dto.Nombre;
            await _service.UpdateDistritoAsync(ent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ent = await _service.GetDistritoByIdAsync(id);
            if (ent == null) return NotFound();
            await _service.DeleteDistritoAsync(ent);
            return NoContent();
        }
    }
}
