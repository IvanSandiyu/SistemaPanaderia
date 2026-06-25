using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.EntityFramework.Configurations
{
    public class MovimientoStockConfiguration : IEntityTypeConfiguration<MovimientoStock>
    {
        public void Configure(EntityTypeBuilder<MovimientoStock> builder)
        {
            builder.ToTable("MovimientosStock");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cantidad)
                .HasColumnType("decimal(18,2)");


            builder.Property(x => x.Fecha)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasConversion<string>();

            builder.HasOne(x => x.Producto)
                .WithMany()
                .HasForeignKey(x => x.ProductoId);
        }
    }
}
