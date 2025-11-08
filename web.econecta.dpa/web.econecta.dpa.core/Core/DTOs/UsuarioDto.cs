using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class UsuarioDto
    {
        public long IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public int? IdDistrito { get; set; }
        public bool CorreoConfirmado { get; set; }
        public string Estado { get; set; } = null!;
        public decimal PuntajePromedio { get; set; }
        public int ConteoPuntajes { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? UltimoIngresoEn { get; set; }
    }
}