using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Panaderia.Domain.Entidades.Productos;
using Panaderia.Domain.Entidades.Ventas;
namespace Panaderia.Infrastructure.EntityFramework
{
    public class PanaderiaDbContext: DbContext, IApplicationDbContext
    {
        public PanaderiaDbContext(
            DbContextOptions<PanaderiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<MovimientoStock> MovimientosStock { get; set; }
        
        public DbSet<DetalleVenta> DetalleVentas { get ; set ; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PanaderiaDbContext).Assembly);
        }
    }
}
