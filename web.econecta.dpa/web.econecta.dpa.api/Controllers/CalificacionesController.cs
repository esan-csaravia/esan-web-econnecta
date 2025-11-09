using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetCalificacionesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var ent = await _service.GetCalificacionByIdAsync(id);
            if (ent == null) return NotFound();
            return Ok(ent);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Calificacione dto)
        {
            await _service.AddCalificacionAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.IdCalificacion }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Calificacione dto)
        {
            if (id != dto.IdCalificacion) return BadRequest();
            var existing = await _service.GetCalificacionByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateCalificacionAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetCalificacionByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteCalificacionAsync(existing);
            return NoContent();
        }
    }
}
