using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlFina.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstOfMonthColumnTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstOfMonth",
                schema: "public",
                table: "tb_transaction");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "tb_transaction",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "public",
                table: "tb_transaction");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstOfMonth",
                schema: "public",
                table: "tb_transaction",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
