using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Shared.DTOs.Productos
{
    public class ProductoMasVendidoDto
    {
        public string Nombre { get; set; }
        public decimal? CantidadVendida { get; set; }
        public decimal? TotalFacturado { get; set; }
    }
}
