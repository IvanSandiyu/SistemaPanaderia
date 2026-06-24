using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs.Ventas
{
    public class ProductoMasVendidoDto
    {
        public string Nombre { get; set; }
        public int CantidadVendida { get; set; }
        public decimal TotalFacturado { get; set; }
    }
}
