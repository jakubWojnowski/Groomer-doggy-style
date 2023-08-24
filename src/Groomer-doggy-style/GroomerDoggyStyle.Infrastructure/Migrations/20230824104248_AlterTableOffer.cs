using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroomerDoggyStyle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightType",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Offers",
                newName: "BasePrice");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "Offers",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "WeightType",
                table: "Offers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
