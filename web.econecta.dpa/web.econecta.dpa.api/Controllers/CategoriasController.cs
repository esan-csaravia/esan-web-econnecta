using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Core.DTOs;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriasController(ICategoriaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetCategoriasAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetCategoriaByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDto dto)
        {
            await _service.AddCategoriaAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.IdCategoria }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CategoriaDto dto)
        {
            if (id != dto.IdCategoria) return BadRequest();
            var existing = await _service.GetCategoriaByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateCategoriaAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetCategoriaByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteCategoriaAsync(id);
            return NoContent();
        }
    }
}
