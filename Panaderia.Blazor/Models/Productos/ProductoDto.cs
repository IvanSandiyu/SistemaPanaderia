namespace Panaderia.Blazor.Models.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal PrecioCompra { get; set; }

        public decimal PrecioVenta { get; set; }

        public int StockActual {  get; set; }
    }
}
