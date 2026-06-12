using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Producto> Productos { get; set; }
        //DbSet<Categoria> Categorias { get; set; }
        DbSet<MovimientoStock> MovimientosStock { get; set; }
        DbSet<Venta> Ventas { get; set; }
        DbSet<DetalleVenta> DetalleVentas{ get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
