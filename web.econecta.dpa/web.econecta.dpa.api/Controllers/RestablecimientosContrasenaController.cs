using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestablecimientosContrasenaController : ControllerBase
    {
        private readonly IRestablecimientosContrasenaService _service;
        public RestablecimientosContrasenaController(IRestablecimientosContrasenaService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestablecimientosContrasenaDto>>> Get()
        {
            var items = await _service.GetRestablecimientosDtosAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestablecimientosContrasenaDto>> Get(long id)
        {
            var dto = await _service.GetRestablecimientoDtoByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<RestablecimientosContrasenaDto>> Post([FromBody] RestablecimientosContrasenaDto dto)
        {
            var ent = new RestablecimientosContrasena { IdUsuario = dto.IdUsuario, Token = dto.Token, ExpiraEn = dto.ExpiraEn, UsadoEn = dto.UsadoEn, CreadoEn = dto.CreadoEn };
            await _service.AddRestablecimientoAsync(ent);
            dto.IdRestablecimiento = ent.IdRestablecimiento;
            return CreatedAtAction(nameof(Get), new { id = ent.IdRestablecimiento }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ent = await _service.GetRestablecimientoByIdAsync(id);
            if (ent == null) return NotFound();
            await _service.DeleteRestablecimientoAsync(ent);
            return NoContent();
        }
    }
}
