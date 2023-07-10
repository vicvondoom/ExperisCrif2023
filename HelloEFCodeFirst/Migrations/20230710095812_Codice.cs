using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Codice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Prodotti",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codice",
                table: "Prodotti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codice",
                table: "Prodotti");

            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Prodotti",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
