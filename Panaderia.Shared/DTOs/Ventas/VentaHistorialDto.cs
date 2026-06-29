using Panaderia.Shared.Enums;
using Panaderia.Shared.Ventas;

namespace Panaderia.Shared.DTOs.Ventas
{
    public class VentaHistorialDto
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal? Total { get; set; }

        public MetodoDePago MetodoPago { get;set; }

        public List<DetalleVentaHistorialDto> Detalles { get; set; } = [];
    }
}
