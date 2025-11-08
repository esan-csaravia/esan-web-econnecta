using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagenesProductoController : ControllerBase
    {
        private readonly ImagenesProductoService _service;
        public ImagenesProductoController(ImagenesProductoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagenesProductoDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(i => new ImagenesProductoDto { IdImagen = i.IdImagen, IdProducto = i.IdProducto, RutaAlmacenamiento = i.RutaAlmacenamiento, Orden = i.Orden, CreadoEn = i.CreadoEn }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagenesProductoDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new ImagenesProductoDto { IdImagen = ent.IdImagen, IdProducto = ent.IdProducto, RutaAlmacenamiento = ent.RutaAlmacenamiento, Orden = ent.Orden, CreadoEn = ent.CreadoEn };
        }

        [HttpPost]
        public async Task<ActionResult<ImagenesProductoDto>> Post([FromBody] ImagenesProductoDto dto)
        {
            var ent = new ImagenesProducto { IdProducto = dto.IdProducto, RutaAlmacenamiento = dto.RutaAlmacenamiento, Orden = dto.Orden, CreadoEn = dto.CreadoEn };
            await _service.AddAsync(ent);
            dto.IdImagen = ent.IdImagen;
            return CreatedAtAction(nameof(Get), new { id = ent.IdImagen }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ImagenesProductoDto dto)
        {
            if (id != dto.IdImagen) return BadRequest();
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            ent.RutaAlmacenamiento = dto.RutaAlmacenamiento;
            ent.Orden = dto.Orden;
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
