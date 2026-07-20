using Panaderia.Shared.DTOs.Proveedores;
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
        public string Nombre { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioCompraUnidad { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal? PrecioVentaUnidad { get; set; }
        public decimal StockActual { get; set; }
        public bool Activo { get; set; }
        public decimal? PorcentajeGanancia { get; set; }
        public decimal? PorcentajeGananciaUnidad { get; set; }
        public int ProveedorId { get; set; } 
    }
    //public record ProductoDTO (
    //    int Id,
    //    string? Nombre,
    //    decimal? PrecioCompra,
    //    decimal? PrecioCompraUnidad,
    //    decimal? PrecioVenta,
    //    decimal? PrecioVentaUnidad,
    //    decimal StockActual,
    //    bool Activo,
    //    decimal? PorcentajeGanancia,
    //    decimal? PorcentajeGananciaUnidad);
}
