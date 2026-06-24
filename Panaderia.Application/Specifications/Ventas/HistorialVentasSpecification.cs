using Ardalis.Specification;
using Panaderia.Domain.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Specifications.Ventas
{
    public class HistorialVentasSpecification : BaseSpecification<Venta>
    {
        public HistorialVentasSpecification() : base (x => true)
        {
            AddInclude(x => x.Detalles);
            ApplyOrderByDescending(x => x.Fecha);
        }
    }
}
