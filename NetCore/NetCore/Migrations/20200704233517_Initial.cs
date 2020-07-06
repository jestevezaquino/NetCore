using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(maxLength: 17, nullable: false),
                    Tituto = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
