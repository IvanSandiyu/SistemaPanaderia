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
    }
    
}
