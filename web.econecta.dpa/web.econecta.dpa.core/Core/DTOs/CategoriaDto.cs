using System;
using System.Collections.Generic;

namespace web.econecta.dpa.core.Core.DTOs
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public int? IdPadre { get; set; }
    }

    public class CategoriaListDto
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
    }

    public class CategoriaDetailDto : CategoriaDto
    {
        // additional fields for detail view can be added here
    }

    public class UsuarioListDto
    {
        public long IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Correo { get; set; } = null!;
    }

    public class DistritoListDto
    {
        public int IdDistrito { get; set; }
        public string Nombre { get; set; } = null!;
    }

    // Minimal DTO to reference a Transaccion from other DTOs (only idProducto and descripcion)
    public class TransaccioneListProductoDto
    {
        public long IdProducto { get; set; }
        public string DescripcionProducto { get; set; } = null!;
    }

}
