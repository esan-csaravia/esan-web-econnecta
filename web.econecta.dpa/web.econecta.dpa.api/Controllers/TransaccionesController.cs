using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var items = await _service.GetTransaccionesDtosAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransaccioneDto>> Get(long id)
        {
            var ent = await _service.GetTransaccionDtoByIdAsync(id);
            if (ent == null) return NotFound();
            return Ok(ent);
        }

        [HttpPost]
        public async Task<ActionResult<TransaccioneDto>> Post([FromBody] TransaccioneDto dto)
        {
            // map first reference ids into entity scalar ids (fallback to 0 if not provided)
            var ent = new Transaccione
            {
                Tipo = dto.Tipo,
                IdProducto = dto.Productos?.FirstOrDefault()?.IdProducto ?? 0,
                IdVendedor = dto.Vendedores?.FirstOrDefault()?.IdUsuario ?? 0,
                IdComprador = dto.Compradores?.FirstOrDefault()?.IdUsuario ?? 0,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario,
                MontoTotal = dto.MontoTotal,
                Estado = dto.Estado,
                CreadoEn = dto.CreadoEn,
                CompletadoEn = dto.CompletadoEn
            };

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
