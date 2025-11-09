using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioService _service;
        public ComentariosController(IComentarioService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetComentariosAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetComentarioByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario entity)
        {
            await _service.AddComentarioAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Comentario entity)
        {
            var existing = await _service.GetComentarioByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateComentarioAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetComentarioByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteComentarioAsync(existing);
            return NoContent();
        }
    }
}
