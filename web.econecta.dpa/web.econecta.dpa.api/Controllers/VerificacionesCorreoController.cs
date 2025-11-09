using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerificacionesCorreoController : ControllerBase
    {
        private readonly IVerificacionesCorreoService _service;
        public VerificacionesCorreoController(IVerificacionesCorreoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetVerificacionesCorreoAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetVerificacionCorreoByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VerificacionesCorreo dto)
        {
            await _service.AddVerificacionCorreoAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.IdVerificacion }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetVerificacionCorreoByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteVerificacionCorreoAsync(existing);
            return NoContent();
        }
    }
}
