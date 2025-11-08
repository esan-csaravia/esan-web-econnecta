using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class NotificacioneDto
    {
        public long IdNotificacion { get; set; }
        public long IdDestinatario { get; set; }
        public string Tipo { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? Cuerpo { get; set; }
        public string Canal { get; set; } = null!;
        public long? IdProductoRelacionado { get; set; }
        public long? IdTransaccionRelacionada { get; set; }
        public DateTime? LeidoEn { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
