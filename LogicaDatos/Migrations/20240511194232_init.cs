using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoProveedor = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rut = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Direccion_Calle_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion_NumeroPuerta_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion_Ciudad_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanciaHastaDeposito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaEntrega = table.Column<DateOnly>(type: "date", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Recargo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlazoEstipulado = table.Column<int>(type: "int", nullable: true),
                    PedidoExpress_Recargo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PedidoExpress_PlazoEstipulado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    UnidadesSolicitadas = table.Column<int>(type: "int", nullable: false),
                    PreciodUnitario = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineas_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "CodigoProveedor", "Descripcion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "1234567890123", "Calculadora de bolsillo Casio", "Calculadora Casio", 300, 10 },
                    { 2, "1234567890124", "500 hojas para imprimir en formato A4", "Resma A4", 250, 50 },
                    { 3, "1234567890125", "Bluetooth o conexión USB, cable desmontable", "Auriculares con Micrófono", 500, 40 },
                    { 4, "1234567890126", "Soporte lumbar, altura ajustable y base giratoria con ruedas", "Silla De Escritorio", 3200, 20 }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "DistanciaHastaDeposito", "RazonSocial", "Rut", "Direccion_Calle_Valor", "Direccion_Ciudad_Valor", "Direccion_NumeroPuerta_Valor" },
                values: new object[,]
                {
                    { 1, 98, "PF", "123456789012", "Ciudadela", "Montevideo", "1180" },
                    { 2, 101, "LZ", "987654321098", "Reconquista", "Montevideo", "600" },
                    { 3, 96, "TWS", "111222333444", "Durazno", "Montevideo", "902" }
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[] { 1, "IVA", 0.18m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "Email", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { 1, "Admin", "Passw0rd!", "admin@admin.com", "Sys", "Administrador" },
                    { 2, "Planta", "Passw0rd!", "rplanta@lz.com", "Roberto", "Estandar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CodigoProveedor",
                table: "Articulos",
                column: "CodigoProveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Nombre",
                table: "Articulos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Rut",
                table: "Clientes",
                column: "Rut",
                unique: true,
                filter: "[Rut] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_ArticuloId",
                table: "Lineas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_PedidoId",
                table: "Lineas",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
