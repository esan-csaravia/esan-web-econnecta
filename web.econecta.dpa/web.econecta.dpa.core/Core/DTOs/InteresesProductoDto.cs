using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class InteresesProductoDto
    {
        public long IdInteres { get; set; }
        public long IdProducto { get; set; }
        public long IdComprador { get; set; }
        public string? Mensaje { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
