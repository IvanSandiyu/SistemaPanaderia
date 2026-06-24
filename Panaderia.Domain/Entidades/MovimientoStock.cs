using Panaderia.Domain.Entidades.Productos;
using Panaderia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Domain.Entidades
{
    public class MovimientoStock
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; } = DateTime.UtcNow;
        public int ProductoId { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public int Cantidad { get; set; } // Siempre registrar en valor absoluto (positivo)
        public string? Observaciones { get; set; }
        public int? ReferenciaId { get; set; } // ID de la Compra o Venta que originó el movimiento

        public Producto? Producto { get; set; }
    }
}
