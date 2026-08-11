namespace Panaderia.Shared.DTOs.Ventas
{
    public class DetalleVentaHistorialDto
    {
        public int ProductoId { get; set; }

        public string Producto { get; set; } = string.Empty;

        public decimal? Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal? Subtotal { get; set; }
    }
}
