using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs
{
    public record VentaDto
    {
        public List<DetalleVentaDTO> Detalles { get; set; } = new List<DetalleVentaDTO>();
        public string MetodoPago { get; set; } = string.Empty;

        public string? Observaciones { get; set; }
    }
    
}
