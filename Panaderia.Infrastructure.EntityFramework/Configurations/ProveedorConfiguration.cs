using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panaderia.Domain.Entidades.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.EntityFramework.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre");

            builder.Property(p => p.Cuit)
                .HasColumnName("Cuit");

            builder.Property(p => p.Telefono)
                .HasColumnName("Telefono");

            builder.Property(p => p.Direccion)
                .HasColumnName("Direccion");

            builder.Property(p => p.Activo)
                .HasColumnName("Activo");

           }
    }
}
