namespace Panaderia.Blazor.Models
{
    public class CarritoItemDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal PrecioVenta { get; set; }

        public int Cantidad { get; set; }
    }
}
