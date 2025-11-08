using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class ComentarioDto
    {
        public long IdComentario { get; set; }
        public long IdProducto { get; set; }
        public long IdAutor { get; set; }
        public string Cuerpo { get; set; } = null!;
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
        public bool Eliminado { get; set; }
    }
}
