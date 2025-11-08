using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentarioService _service;
        public ComentariosController(ComentarioService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(c => new ComentarioDto { IdComentario = c.IdComentario, IdProducto = c.IdProducto, IdAutor = c.IdAutor, Cuerpo = c.Cuerpo, CreadoEn = c.CreadoEn, ActualizadoEn = c.ActualizadoEn, Eliminado = c.Eliminado }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new ComentarioDto { IdComentario = ent.IdComentario, IdProducto = ent.IdProducto, IdAutor = ent.IdAutor, Cuerpo = ent.Cuerpo, CreadoEn = ent.CreadoEn, ActualizadoEn = ent.ActualizadoEn, Eliminado = ent.Eliminado };
        }

        [HttpPost]
        public async Task<ActionResult<ComentarioDto>> Post([FromBody] ComentarioDto dto)
        {
            var ent = new Comentario { IdProducto = dto.IdProducto, IdAutor = dto.IdAutor, Cuerpo = dto.Cuerpo, CreadoEn = dto.CreadoEn, ActualizadoEn = dto.ActualizadoEn, Eliminado = dto.Eliminado };
            await _service.AddAsync(ent);
            dto.IdComentario = ent.IdComentario;
            return CreatedAtAction(nameof(Get), new { id = ent.IdComentario }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ComentarioDto dto)
        {
            if (id != dto.IdComentario) return BadRequest();
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            ent.Cuerpo = dto.Cuerpo;
            ent.ActualizadoEn = dto.ActualizadoEn;
            ent.Eliminado = dto.Eliminado;
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
