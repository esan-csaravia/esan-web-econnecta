using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class VerificacionesCorreoDto
    {
        public long IdVerificacion { get; set; }
        public long IdUsuario { get; set; }
        public string Token { get; set; } = null!;
        public DateTime EnviadoEn { get; set; }
        public DateTime? ConfirmadoEn { get; set; }
    }
}
