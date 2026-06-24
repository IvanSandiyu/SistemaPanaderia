using Panaderia.Application.DTOs.Ventas;

namespace Panaderia.Blazor.Models.Ventas
{
    public class VentaHistorialDto
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public List<DetalleVentaHistorialDTO> Detalles { get; set; } = [];
    }
}
