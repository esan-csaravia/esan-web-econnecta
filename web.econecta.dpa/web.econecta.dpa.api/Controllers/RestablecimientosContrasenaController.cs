using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestablecimientosContrasenaController : ControllerBase
    {
        private readonly RestablecimientosContrasenaService _service;
        public RestablecimientosContrasenaController(RestablecimientosContrasenaService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestablecimientosContrasenaDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(r => new RestablecimientosContrasenaDto { IdRestablecimiento = r.IdRestablecimiento, IdUsuario = r.IdUsuario, Token = r.Token, ExpiraEn = r.ExpiraEn, UsadoEn = r.UsadoEn, CreadoEn = r.CreadoEn }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestablecimientosContrasenaDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new RestablecimientosContrasenaDto { IdRestablecimiento = ent.IdRestablecimiento, IdUsuario = ent.IdUsuario, Token = ent.Token, ExpiraEn = ent.ExpiraEn, UsadoEn = ent.UsadoEn, CreadoEn = ent.CreadoEn };
        }

        [HttpPost]
        public async Task<ActionResult<RestablecimientosContrasenaDto>> Post([FromBody] RestablecimientosContrasenaDto dto)
        {
            var ent = new RestablecimientosContrasena { IdUsuario = dto.IdUsuario, Token = dto.Token, ExpiraEn = dto.ExpiraEn, UsadoEn = dto.UsadoEn, CreadoEn = dto.CreadoEn };
            await _service.AddAsync(ent);
            dto.IdRestablecimiento = ent.IdRestablecimiento;
            return CreatedAtAction(nameof(Get), new { id = ent.IdRestablecimiento }, dto);
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
