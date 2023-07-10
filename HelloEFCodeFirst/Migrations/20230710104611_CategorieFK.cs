using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class CategorieFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_Categoria",
                table: "Prodotti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ID_Categoria",
                table: "Prodotti",
                column: "ID_Categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Categorie_ID_Categoria",
                table: "Prodotti",
                column: "ID_Categoria",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Categorie_ID_Categoria",
                table: "Prodotti");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Prodotti_ID_Categoria",
                table: "Prodotti");

            migrationBuilder.DropColumn(
                name: "ID_Categoria",
                table: "Prodotti");
        }
    }
}
