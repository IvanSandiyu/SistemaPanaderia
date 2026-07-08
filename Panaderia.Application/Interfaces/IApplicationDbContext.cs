using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panaderia.Domain.Entidades.Productos;
using Panaderia.Domain.Entidades.Ventas;
using Panaderia.Domain.Entidades.Proveedores;

namespace Panaderia.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Producto> Productos { get; set; }
        //DbSet<Categoria> Categorias { get; set; }
        DbSet<MovimientoStock> MovimientosStock { get; set; }
        DbSet<Venta> Ventas { get; set; }
        DbSet<DetalleVenta> DetalleVentas{ get; set; }

        DbSet<Proveedor> Proveedores { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
