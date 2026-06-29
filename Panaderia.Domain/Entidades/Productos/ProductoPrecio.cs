using Panaderia.Domain.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Domain.Entidades.Productos
{
    public class ProductoPrecio
    {
        public int ProductoId { get; set; }
        public TipoVenta TipoVenta { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PorcentajeGanancia { get; set; }
    }
}
