using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class CalificacioneDto
    {
        public long IdCalificacion { get; set; }
        public long IdTransaccion { get; set; }
        public long IdCalificador { get; set; }
        public long IdCalificado { get; set; }
        public byte Estrellas { get; set; }
        public string? Comentario { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
