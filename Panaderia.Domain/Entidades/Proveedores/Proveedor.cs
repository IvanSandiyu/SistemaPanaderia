using Panaderia.Domain.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Domain.Entidades.Proveedores
{
    public class Proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Cuit { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Direccion { get; set; }

        public bool Activo { get; set; }
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
