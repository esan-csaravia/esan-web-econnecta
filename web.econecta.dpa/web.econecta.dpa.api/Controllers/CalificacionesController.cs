using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalificacionesController : ControllerBase
    {
        private readonly ICalificacioneService _service;

        public CalificacionesController(ICalificacioneService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalificacioneDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(c => new CalificacioneDto
            {
                IdCalificacion = c.IdCalificacion,
                IdTransaccion = c.IdTransaccion,
                IdCalificador = c.IdCalificador,
                IdCalificado = c.IdCalificado,
                Estrellas = c.Estrellas,
                Comentario = c.Comentario,
                CreadoEn = c.CreadoEn
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CalificacioneDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new CalificacioneDto
            {
                IdCalificacion = ent.IdCalificacion,
                IdTransaccion = ent.IdTransaccion,
                IdCalificador = ent.IdCalificador,
                IdCalificado = ent.IdCalificado,
                Estrellas = ent.Estrellas,
                Comentario = ent.Comentario,
                CreadoEn = ent.CreadoEn
            };
        }

        [HttpPost]
        public async Task<ActionResult<CalificacioneDto>> Post([FromBody] CalificacioneDto dto)
        {
            var ent = new Calificacione
            {
                IdTransaccion = dto.IdTransaccion,
                IdCalificador = dto.IdCalificador,
                IdCalificado = dto.IdCalificado,
                Estrellas = dto.Estrellas,
                Comentario = dto.Comentario,
                CreadoEn = dto.CreadoEn
            };

            await _service.AddAsync(ent);
            dto.IdCalificacion = ent.IdCalificacion;
            return CreatedAtAction(nameof(Get), new { id = ent.IdCalificacion }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CalificacioneDto dto)
        {
            if (id != dto.IdCalificacion) return BadRequest();
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            ent.Estrellas = dto.Estrellas;
            ent.Comentario = dto.Comentario;
            ent.CreadoEn = dto.CreadoEn;
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
