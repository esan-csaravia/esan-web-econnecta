using System;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class TransaccioneDto
    {
        public long IdTransaccion { get; set; }
        public string Tipo { get; set; } = null!;
        public List<ProductoDto> Productos { get; set; } = new();
        public List<UsuarioListDto> Vendedores { get; set; } = new();
        public List<UsuarioListDto> Compradores { get; set; } = new();
        public int Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? MontoTotal { get; set; }
        public string Estado { get; set; } = null!;
        public DateTime CreadoEn { get; set; }
        public DateTime? CompletadoEn { get; set; }
    }
}
