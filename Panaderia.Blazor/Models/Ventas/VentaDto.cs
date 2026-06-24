namespace Panaderia.Blazor.Models.Ventas
{
    public class VentaDto
    {
        public List<DetalleVentaDto> Detalles { get; set; } = new();
        public string MetodoPago { get; set; } = string.Empty;

        public string? Observaciones { get; set; }
    }
}
