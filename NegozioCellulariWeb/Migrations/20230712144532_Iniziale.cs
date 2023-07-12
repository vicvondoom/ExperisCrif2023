using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegozioCellulariWeb.Migrations
{
    /// <inheritdoc />
    public partial class Iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cellulari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Modello = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Prezzo = table.Column<int>(type: "int", nullable: false),
                    DataAcquisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeImmagine = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellulari", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cellulari");
        }
    }
}
