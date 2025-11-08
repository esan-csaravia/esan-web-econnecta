using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class ImagenesProductoDto
    {
        public long IdImagen { get; set; }
        public long IdProducto { get; set; }
        public string RutaAlmacenamiento { get; set; } = null!;
        public byte Orden { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
