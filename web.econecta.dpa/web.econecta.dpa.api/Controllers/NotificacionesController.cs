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
            var items = await _service.GetNotificacionesDtosAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacioneDto>> Get(long id)
        {
            var dto = await _service.GetNotificacioneDtoByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<NotificacioneDto>> Post([FromBody] NotificacioneDto dto)
        {
            var ent = new Notificacione { IdDestinatario = dto.IdDestinatario, Tipo = dto.Tipo, Titulo = dto.Titulo, Cuerpo = dto.Cuerpo, Canal = dto.Canal, IdProductoRelacionado = dto.IdProductoRelacionado, IdTransaccionRelacionada = dto.IdTransaccionRelacionada, LeidoEn = dto.LeidoEn, CreadoEn = dto.CreadoEn };
            await _service.AddNotificacioneAsync(ent);
            dto.IdNotificacion = ent.IdNotificacion;
            return CreatedAtAction(nameof(Get), new { id = ent.IdNotificacion }, dto);
        }
    }
}
