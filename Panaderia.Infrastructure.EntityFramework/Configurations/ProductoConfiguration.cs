using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panaderia.Domain.Entidades;

namespace Panaderia.Infrastructure.EntityFramework.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos"); // Nombre de la tabla en SQL

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.PrecioVenta)
                   .HasPrecision(18, 2); // Vital para dinero: 18 dígitos total, 2 decimales
        }
    }
}
