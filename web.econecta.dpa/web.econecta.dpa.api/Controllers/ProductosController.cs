using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
        {
            var result = await _service.GetProductosAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductoById(long id)
        {
            var result = await _service.GetProductoByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> AddProducto([FromBody] ProductoDto dto)
        {
            await _service.AddProductoAsync(dto);
            return CreatedAtAction(nameof(GetProductoById), new { id = dto.IdProducto }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(long id, [FromBody] ProductoDto dto)
        {
            if (id != dto.IdProducto) return BadRequest();
            var existing = await _service.GetProductoByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.UpdateProductoAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(long id)
        {
            var existing = await _service.GetProductoByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteProductoAsync(id);
            return NoContent();
        }
    }
}
