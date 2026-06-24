using Panaderia.Domain.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Specifications
{
    public class ProductoConCategoriaSpecification : BaseSpecification<Producto>
    {
        public ProductoConCategoriaSpecification(int? categoriaId = null)
            : base(p => !categoriaId.HasValue || p.CategoriaId == categoriaId.Value)
        {
            //AddInclude(p => p.Categoria!);
        }
    }
}
