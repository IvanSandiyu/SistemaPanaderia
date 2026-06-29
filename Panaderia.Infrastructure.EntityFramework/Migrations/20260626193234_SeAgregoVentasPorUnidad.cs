using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Panaderia.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregoVentasPorUnidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoVenta",
                table: "Productos");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioVenta",
                table: "Productos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioCompra",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeGananciaUnidad",
                table: "Productos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCompraUnidad",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioVentaUnidad",
                table: "Productos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeGananciaUnidad",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioCompraUnidad",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioVentaUnidad",
                table: "Productos");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioVenta",
                table: "Productos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioCompra",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoVenta",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
