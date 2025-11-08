using Microsoft.AspNetCore.Mvc;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Core.Services;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _service;
        public RolesController(RoleService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
        {
            var items = await _service.GetAllAsync();
            return items.Select(r => new RoleDto { IdRol = r.IdRol, Nombre = r.Nombre }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> Get(long id)
        {
            var ent = await _service.GetByIdAsync(id);
            if (ent == null) return NotFound();
            return new RoleDto { IdRol = ent.IdRol, Nombre = ent.Nombre };
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Post([FromBody] RoleDto dto)
        {
            var ent = new Role { Nombre = dto.Nombre };
            await _service.AddAsync(ent);
            dto.IdRol = ent.IdRol;
            return CreatedAtAction(nameof(Get), new { id = ent.IdRol }, dto);
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
