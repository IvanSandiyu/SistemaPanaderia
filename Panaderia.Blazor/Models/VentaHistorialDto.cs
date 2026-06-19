using Panaderia.Application.DTOs;

namespace Panaderia.Blazor.Models
{
    public class VentaHistorialDto
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public List<DetalleVentaHistorialDTO> Detalles { get; set; } = [];
    }
}
