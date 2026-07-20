using Panaderia.Domain.Entidades.Proveedores;
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
        public required string Nombre { get; set; }
        public string? CodigoBarras { get; set; }
        
        //Costos
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioCompraUnidad { get; set; }

        //Ventas
        public decimal? PrecioVenta { get; set; }
        public decimal? PrecioVentaUnidad { get; set; }

        //Ganancias
        public decimal? PorcentajeGanancia { get; set; }
        public decimal? PorcentajeGananciaUnidad { get; set; }
        
        public int CategoriaId { get; set; }
        public decimal? StockActual { get; set; } // Actúa como caché rápido de lectura
        public bool? Activo { get; set; } = true;

        //Proveedores
        public int? ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        // Propiedades de navegación
        //public Categoria? Categoria { get; set; }
    }
}
