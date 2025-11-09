using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InteresesProductoController : ControllerBase
    {
        private readonly IInteresesProductoService _service;
        public InteresesProductoController(IInteresesProductoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetInteresesProductoAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetInteresProductoByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InteresesProducto dto)
        {
            await _service.AddInteresProductoAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.IdInteres }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetInteresProductoByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteInteresProductoAsync(existing);
            return NoContent();
        }
    }
}
