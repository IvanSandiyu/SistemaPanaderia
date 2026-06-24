namespace Panaderia.Blazor.Models.Ventas
{
    public class DetalleVentaHistorialDto
    {
        public int ProductoId { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }
    }
}
