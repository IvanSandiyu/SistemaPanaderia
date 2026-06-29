using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs.Producto
{
    public record ProductoDTO (
        string Nombre,
        decimal? PrecioCompra,
        decimal? PrecioCompraUnidad,
        decimal? PrecioVenta,
        decimal? PrecioVentaUnidad,
        decimal StockActual,
        bool Activo,
        decimal? PorcentajeGanancia,
        decimal? PorcentajeGananciaUnidad);
}
