using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.ToyCollector.Migrations.EFCore.Migrations
{
    public partial class AdditionalPropertiesForValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DiscontinuedDate",
                table: "Toys",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Msrp",
                table: "Toys",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LimitedEdition",
                table: "Toys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscontinuedDate",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "Msrp",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "LimitedEdition",
                table: "Toys");
        }
    }
}
