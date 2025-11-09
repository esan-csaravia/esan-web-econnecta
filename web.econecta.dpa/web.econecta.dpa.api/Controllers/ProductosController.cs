using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _service;

        public ProductosController(IProductoRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
        {
            var result = await _service.GetAllDtosAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> Get(long id)
        {
            var result = await _service.GetDtoByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Post([FromBody] ProductoDto dto)
        {
            await _service.AddDtoAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.IdProducto }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ProductoDto dto)
        {
            if (id != dto.IdProducto) return BadRequest();
            var existing = await _service.GetDtoByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateDtoAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _service.GetDtoByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteDtoAsync(id);
            return NoContent();
        }
    }
}
