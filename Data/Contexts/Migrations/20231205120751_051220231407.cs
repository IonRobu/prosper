using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _051220231407 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Transaction",
                type: "TEXT COLLATE NOCASE",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transaction",
                type: "TEXT COLLATE NOCASE",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "TEXT COLLATE NOCASE",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "TEXT COLLATE NOCASE",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Card",
                type: "TEXT COLLATE NOCASE",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Card",
                type: "TEXT COLLATE NOCASE",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Card",
                type: "TEXT COLLATE NOCASE",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Account",
                type: "TEXT COLLATE NOCASE",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Account",
                type: "TEXT COLLATE NOCASE",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldCollation: "NOCASE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Transaction",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transaction",
                type: "TEXT",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldNullable: true,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "TEXT",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldNullable: true,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Card",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Card",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Card",
                type: "TEXT",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldNullable: true,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Account",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldMaxLength: 250,
                oldCollation: "NOCASE");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Account",
                type: "TEXT",
                nullable: true,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT COLLATE NOCASE",
                oldNullable: true,
                oldCollation: "NOCASE");
        }
    }
}
