namespace Panaderia.Blazor.Models.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal PrecioCompra { get; set; }
        public decimal? PrecioCompraUnidad { get; set; }

        public decimal PrecioVenta { get; set; }
        public decimal? PrecioVentaUnidad { get; set; }

        public decimal StockActual {  get; set; }

        public decimal PorcentajeGanancia { get; set; }
        public decimal? PorcentajeGananciaUnidad { get; set; }
    }
}
