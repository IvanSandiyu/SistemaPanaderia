using Panaderia.Shared.DTOs;
using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panaderia.Shared.Ventas;
using Panaderia.Shared.DTOs.Productos;

namespace Panaderia.Application.DTOs.Dashboard
{
    public class DashboardDto
    {
        public decimal VentasHoy { get; set; }

        public decimal VentasMes { get; set; }

        public decimal GananciaMes { get; set; }

        public decimal TicketPromedio { get; set; }

        public List<VentaDiariaDto> VentasDiarias { get; set; }

        public List<ProductoMasVendidoDto> ProductosMasVendidos { get; set; }

        public List<MetodoPagoDto> MetodosPago { get; set; }
    }
}
