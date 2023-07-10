using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class PrezzoDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prezzo",
                table: "Prodotti",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prezzo",
                table: "Prodotti",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
