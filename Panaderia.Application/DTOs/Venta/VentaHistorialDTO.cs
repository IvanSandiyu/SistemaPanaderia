using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs.Ventas
{
    public record VentaHistorialDTO
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public List<DetalleVentaHistorialDTO> Detalles { get; set; } = [];

    }


}
