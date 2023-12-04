using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _041220232032 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Category",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Category",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixed",
                table: "Category",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsFixed",
                table: "Category");
        }
    }
}
