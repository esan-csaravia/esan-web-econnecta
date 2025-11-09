using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccioneService _service;
        public TransaccionesController(ITransaccioneService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransaccioneDto>>> Get()
        {
            var items = await _service.GetTransaccionesAsync();
            return items.Select(t => new TransaccioneDto { IdTransaccion = t.IdTransaccion, Tipo = t.Tipo, IdProducto = t.IdProducto, IdVendedor = t.IdVendedor, IdComprador = t.IdComprador, Cantidad = t.Cantidad, PrecioUnitario = t.PrecioUnitario, MontoTotal = t.MontoTotal, Estado = t.Estado, CreadoEn = t.CreadoEn, CompletadoEn = t.CompletadoEn }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransaccioneDto>> Get(long id)
        {
            var ent = await _service.GetTransaccionByIdAsync(id);
            if (ent == null) return NotFound();
            return new TransaccioneDto { IdTransaccion = ent.IdTransaccion, Tipo = ent.Tipo, IdProducto = ent.IdProducto, IdVendedor = ent.IdVendedor, IdComprador = ent.IdComprador, Cantidad = ent.Cantidad, PrecioUnitario = ent.PrecioUnitario, MontoTotal = ent.MontoTotal, Estado = ent.Estado, CreadoEn = ent.CreadoEn, CompletadoEn = ent.CompletadoEn };
        }

        [HttpPost]
        public async Task<ActionResult<TransaccioneDto>> Post([FromBody] TransaccioneDto dto)
        {
            var ent = new Transaccione { Tipo = dto.Tipo, IdProducto = dto.IdProducto, IdVendedor = dto.IdVendedor, IdComprador = dto.IdComprador, Cantidad = dto.Cantidad, PrecioUnitario = dto.PrecioUnitario, MontoTotal = dto.MontoTotal, Estado = dto.Estado, CreadoEn = dto.CreadoEn, CompletadoEn = dto.CompletadoEn };
            await _service.AddTransaccionAsync(ent);
            dto.IdTransaccion = ent.IdTransaccion;
            return CreatedAtAction(nameof(Get), new { id = ent.IdTransaccion }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] TransaccioneDto dto)
        {
            if (id != dto.IdTransaccion) return BadRequest();
            var ent = await _service.GetTransaccionByIdAsync(id);
            if (ent == null) return NotFound();
            ent.Estado = dto.Estado;
            ent.CompletadoEn = dto.CompletadoEn;
            await _service.UpdateTransaccionAsync(ent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ent = await _service.GetTransaccionByIdAsync(id);
            if (ent == null) return NotFound();
            await _service.DeleteTransaccionAsync(ent);
            return NoContent();
        }
    }
}
