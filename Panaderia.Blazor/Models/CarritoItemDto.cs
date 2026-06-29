using Panaderia.Shared.Enums;

namespace Panaderia.Blazor.Models
{
    public class CarritoItemDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public TipoVenta TipoVenta { get; set; }
        // Para calcular el precio final
        public decimal PrecioAplicado { get; set; }

        public decimal? Subtotal => Cantidad * PrecioAplicado;
        
    }
}
