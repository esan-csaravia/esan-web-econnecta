using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetUsuariosAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetUsuarioByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario dto)
        {
            await _service.AddUsuarioAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.IdUsuario }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Usuario dto)
        {
            if (id != dto.IdUsuario) return BadRequest();
            var existing = await _service.GetUsuarioByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateUsuarioAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetUsuarioByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteUsuarioAsync(existing);
            return NoContent();
        }
    }
}
