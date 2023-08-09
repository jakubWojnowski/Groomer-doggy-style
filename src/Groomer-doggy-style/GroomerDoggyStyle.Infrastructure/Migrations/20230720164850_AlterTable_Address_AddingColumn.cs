using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroomerDoggyStyle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_Address_AddingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Dogs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "GroomerShopId",
                table: "Addresses",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroomerShopId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Dogs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
