using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Distribuidora_MC_DB.Migrations
{
    /// <inheritdoc />
    public partial class finalbackend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedor_ProveedorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Productos",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "RUC",
                table: "Proveedores",
                newName: "Ruc");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Proveedores",
                newName: "TelefonoProveedor");

            migrationBuilder.AddColumn<string>(
                name: "CodigoProducto",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "Productos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailProveedor",
                table: "Proveedores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Ruc");

            migrationBuilder.CreateTable(
                name: "informacionProductos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Imagen = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_informacionProductos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_informacionProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precios",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PrecioEfectivo = table.Column<float>(type: "REAL", nullable: false),
                    PrecioCredito = table.Column<float>(type: "REAL", nullable: false),
                    PrecioUnidad = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precios", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Precios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Ruc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "informacionProductos");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "CodigoProducto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "EmailProveedor",
                table: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Productos",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "Ruc",
                table: "Proveedor",
                newName: "RUC");

            migrationBuilder.RenameColumn(
                name: "TelefonoProveedor",
                table: "Proveedor",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Proveedor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "RUC");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedor_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "RUC");
        }
    }
}
