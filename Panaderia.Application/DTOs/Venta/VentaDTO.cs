using Panaderia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs.Ventas
{
    public record VentaDto
    {
        public List<DetalleVentaDTO> Detalles { get; set; } = new List<DetalleVentaDTO>();
        public MetodoDePago MetodoPago { get; set; } 

        public string? Observaciones { get; set; }
    }
    
}
