using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.DTOs;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly EcoConectaDBContext _context;

        public UsuariosController(EcoConectaDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            return await _context.Usuarios.Select(u => new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                NombreCompleto = u.NombreCompleto,
                Correo = u.Correo,
                IdDistrito = u.IdDistrito,
                CorreoConfirmado = u.CorreoConfirmado,
                Estado = u.Estado,
                PuntajePromedio = u.PuntajePromedio,
                ConteoPuntajes = u.ConteoPuntajes,
                CreadoEn = u.CreadoEn,
                UltimoIngresoEn = u.UltimoIngresoEn
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> Get(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdDistrito = usuario.IdDistrito,
                CorreoConfirmado = usuario.CorreoConfirmado,
                Estado = usuario.Estado,
                PuntajePromedio = usuario.PuntajePromedio,
                ConteoPuntajes = usuario.ConteoPuntajes,
                CreadoEn = usuario.CreadoEn,
                UltimoIngresoEn = usuario.UltimoIngresoEn
            };
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto dto)
        {
            var usuario = new Usuario
            {
                NombreCompleto = dto.NombreCompleto,
                Correo = dto.Correo,
                IdDistrito = dto.IdDistrito,
                CorreoConfirmado = dto.CorreoConfirmado,
                Estado = dto.Estado,
                PuntajePromedio = dto.PuntajePromedio,
                ConteoPuntajes = dto.ConteoPuntajes,
                CreadoEn = dto.CreadoEn,
                UltimoIngresoEn = dto.UltimoIngresoEn,
                HashContrasena = new byte[0]
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            dto.IdUsuario = usuario.IdUsuario;
            return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UsuarioDto dto)
        {
            if (id != dto.IdUsuario) return BadRequest();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            usuario.NombreCompleto = dto.NombreCompleto;
            usuario.Correo = dto.Correo;
            usuario.IdDistrito = dto.IdDistrito;
            usuario.CorreoConfirmado = dto.CorreoConfirmado;
            usuario.Estado = dto.Estado;
            usuario.PuntajePromedio = dto.PuntajePromedio;
            usuario.ConteoPuntajes = dto.ConteoPuntajes;
            usuario.UltimoIngresoEn = dto.UltimoIngresoEn;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Usuarios.AnyAsync(e => e.IdUsuario == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
