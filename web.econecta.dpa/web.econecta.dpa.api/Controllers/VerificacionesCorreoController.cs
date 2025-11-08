using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerificacionesCorreoController : ControllerBase
    {
        private readonly VerificacionesCorreoService _service;
        public VerificacionesCorreoController(VerificacionesCorreoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerificacionesCorreoDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(v => new VerificacionesCorreoDto { IdVerificacion = v.IdVerificacion, IdUsuario = v.IdUsuario, Token = v.Token, EnviadoEn = v.EnviadoEn, ConfirmadoEn = v.ConfirmadoEn }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerificacionesCorreoDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new VerificacionesCorreoDto { IdVerificacion = ent.IdVerificacion, IdUsuario = ent.IdUsuario, Token = ent.Token, EnviadoEn = ent.EnviadoEn, ConfirmadoEn = ent.ConfirmadoEn };
        }

        [HttpPost]
        public async Task<ActionResult<VerificacionesCorreoDto>> Post([FromBody] VerificacionesCorreoDto dto)
        {
            var ent = new VerificacionesCorreo { IdUsuario = dto.IdUsuario, Token = dto.Token, EnviadoEn = dto.EnviadoEn, ConfirmadoEn = dto.ConfirmadoEn };
            await _service.AddAsync(ent);
            dto.IdVerificacion = ent.IdVerificacion;
            return CreatedAtAction(nameof(Get), new { id = ent.IdVerificacion }, dto);
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
