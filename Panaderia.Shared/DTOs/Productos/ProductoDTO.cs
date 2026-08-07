using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Shared.DTOs.Productos
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioCompraUnidad { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal? PrecioVentaUnidad { get; set; }
        public decimal StockActual { get; set; }
        public bool? Activo { get; set; }
        public decimal? PorcentajeGanancia { get; set; }
        public decimal? PorcentajeGananciaUnidad { get; set; }
        public int? ProveedorId { get; set; }
    }
}
