using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InteresesProductoController : ControllerBase
    {
        private readonly InteresesProductoService _service;
        public InteresesProductoController(InteresesProductoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteresesProductoDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(i => new InteresesProductoDto { IdInteres = i.IdInteres, IdProducto = i.IdProducto, IdComprador = i.IdComprador, Mensaje = i.Mensaje, CreadoEn = i.CreadoEn }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InteresesProductoDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new InteresesProductoDto { IdInteres = ent.IdInteres, IdProducto = ent.IdProducto, IdComprador = ent.IdComprador, Mensaje = ent.Mensaje, CreadoEn = ent.CreadoEn };
        }

        [HttpPost]
        public async Task<ActionResult<InteresesProductoDto>> Post([FromBody] InteresesProductoDto dto)
        {
            var ent = new InteresesProducto { IdProducto = dto.IdProducto, IdComprador = dto.IdComprador, Mensaje = dto.Mensaje, CreadoEn = dto.CreadoEn };
            await _service.AddAsync(ent);
            dto.IdInteres = ent.IdInteres;
            return CreatedAtAction(nameof(Get), new { id = ent.IdInteres }, dto);
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
