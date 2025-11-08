using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class RestablecimientosContrasenaDto
    {
        public long IdRestablecimiento { get; set; }
        public long IdUsuario { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiraEn { get; set; }
        public DateTime? UsadoEn { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
