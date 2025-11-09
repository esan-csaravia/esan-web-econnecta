using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacioneService _service;
        public NotificacionesController(INotificacioneService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacioneDto>>> Get()
        {
            var items = await _service.GetNotificacionesAsync();
            return items.Select(n => new NotificacioneDto { IdNotificacion = n.IdNotificacion, IdDestinatario = n.IdDestinatario, Tipo = n.Tipo, Titulo = n.Titulo, Cuerpo = n.Cuerpo, Canal = n.Canal, IdProductoRelacionado = n.IdProductoRelacionado, IdTransaccionRelacionada = n.IdTransaccionRelacionada, LeidoEn = n.LeidoEn, CreadoEn = n.CreadoEn }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacioneDto>> Get(long id)
        {
            var ent = await _service.GetNotificacioneByIdAsync(id);
            if (ent == null) return NotFound();
            return new NotificacioneDto { IdNotificacion = ent.IdNotificacion, IdDestinatario = ent.IdDestinatario, Tipo = ent.Tipo, Titulo = ent.Titulo, Cuerpo = ent.Cuerpo, Canal = ent.Canal, IdProductoRelacionado = ent.IdProductoRelacionado, IdTransaccionRelacionada = ent.IdTransaccionRelacionada, LeidoEn = ent.LeidoEn, CreadoEn = ent.CreadoEn };
        }

        [HttpPost]
        public async Task<ActionResult<NotificacioneDto>> Post([FromBody] NotificacioneDto dto)
        {
            var ent = new Notificacione { IdDestinatario = dto.IdDestinatario, Tipo = dto.Tipo, Titulo = dto.Titulo, Cuerpo = dto.Cuerpo, Canal = dto.Canal, IdProductoRelacionado = dto.IdProductoRelacionado, IdTransaccionRelacionada = dto.IdTransaccionRelacionada, LeidoEn = dto.LeidoEn, CreadoEn = dto.CreadoEn };
            await _service.AddNotificacioneAsync(ent);
            dto.IdNotificacion = ent.IdNotificacion;
            return CreatedAtAction(nameof(Get), new { id = ent.IdNotificacion }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] NotificacioneDto dto)
        {
            if (id != dto.IdNotificacion) return BadRequest();
            var ent = await _service.GetNotificacioneByIdAsync(id);
            if (ent == null) return NotFound();
            ent.LeidoEn = dto.LeidoEn;
            await _service.UpdateNotificacioneAsync(ent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ent = await _service.GetNotificacioneByIdAsync(id);
            if (ent == null) return NotFound();
            await _service.DeleteNotificacioneAsync(ent);
            return NoContent();
        }
    }
}
