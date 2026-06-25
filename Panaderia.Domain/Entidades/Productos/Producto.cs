using Panaderia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Domain.Entidades.Productos
{
    public class Producto
    {
        public int Id { get; set; }
        public string? CodigoBarras { get; set; }
        public required string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal StockActual { get; set; } // Actúa como caché rápido de lectura

        public decimal? PorcentajeGanancia { get; set; }
        public TipoVenta TipoVenta { get; set; }


        public bool? Activo { get; set; } = true;

        // Propiedades de navegación
        //public Categoria? Categoria { get; set; }
    }
}
