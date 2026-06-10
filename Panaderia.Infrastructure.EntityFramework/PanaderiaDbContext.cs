using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Panaderia.Infrastructure.EntityFramework
{
    public class PanaderiaDbContext : DbContext, IApplicationDbContext
    {
        public PanaderiaDbContext(DbContextOptions<PanaderiaDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }
        
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones Fluent API
            //modelBuilder.Entity<Producto>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
            //    entity.Property(e => e.PrecioCompra).HasPrecision(18, 2);
            //    entity.Property(e => e.PrecioVenta).HasPrecision(18, 2);

            //    entity.HasOne(d => d.Categoria)
            //          .WithMany(p => p.Productos)
            //          .HasForeignKey(d => d.CategoriaId);
            //});

            //modelBuilder.Entity<MovimientoStock>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Tipo).HasConversion<int>();
            //});
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PanaderiaDbContext).Assembly);
        }
    }
}
