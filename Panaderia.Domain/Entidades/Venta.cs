using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Domain.Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public string MetodoPago { get; set; }

        public string? Observaciones { get; set; }

    }
}
