using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class ProductoDto
    {
        public long IdProducto { get; set; }
        public long IdVendedor { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int IdCategoria { get; set; }
        public string TipoPublicacion { get; set; } = null!;
        public string Condicion { get; set; } = null!;
        public decimal? Precio { get; set; }
        public int Cantidad { get; set; }
        public int? IdDistrito { get; set; }
        public string EstadoModeracion { get; set; } = null!;
        public string? MotivoModeracion { get; set; }
        public long? IdModerador { get; set; }
        public bool Activo { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
    }
}