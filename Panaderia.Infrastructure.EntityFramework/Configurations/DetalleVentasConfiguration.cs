using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panaderia.Domain.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.EntityFramework.Configurations
{
    public class DetalleVentasConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVentas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cantidad)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.PrecioUnitario)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Subtotal)
                .HasColumnType("decimal(18,2)");


            builder.HasOne(x => x.Producto)
                .WithMany()
                .HasForeignKey(x => x.ProductoId);

            builder.HasOne(x => x.Venta)
                .WithMany(x => x.Detalles)
                .HasForeignKey(x => x.VentaId);
        }
    }
}
