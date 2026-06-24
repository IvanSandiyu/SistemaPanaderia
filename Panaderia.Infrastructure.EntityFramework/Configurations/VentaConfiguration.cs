using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.EntityFramework.Configurations
{
    internal class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Ventas");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Fecha).IsRequired();
            builder.Property(v => v.Total).HasColumnType("decimal(18,2)");
            builder.Property(v => v.MetodoPago);
            builder.Property(v => v.Observaciones);
            builder.Property(v => v.MetodoPago).HasConversion<string>();

            builder.HasMany(v => v.Detalles)
            .WithOne(v => v.Venta)
            .HasForeignKey(v => v.VentaId);
        }
    }
}
