using System;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public int? IdPadre { get; set; }
    }
}
