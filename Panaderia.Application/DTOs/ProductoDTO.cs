using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs
{
    public record ProductoDTO (
        string Nombre,
        decimal PrecioCompra,
        decimal PrecioVenta);
}
