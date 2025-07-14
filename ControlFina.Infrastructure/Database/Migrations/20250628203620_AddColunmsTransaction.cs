using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlFina.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddColunmsTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_debit",
                schema: "public",
                table: "tb_transaction",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "observation",
                schema: "public",
                table: "tb_transaction",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_debit",
                schema: "public",
                table: "tb_transaction");

            migrationBuilder.DropColumn(
                name: "observation",
                schema: "public",
                table: "tb_transaction");
        }
    }
}
