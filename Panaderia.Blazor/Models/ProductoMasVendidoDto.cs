namespace Panaderia.Blazor.Models
{
    public class ProductoMasVendidoDto
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int CantidadVendida { get; set; }
    }
}
