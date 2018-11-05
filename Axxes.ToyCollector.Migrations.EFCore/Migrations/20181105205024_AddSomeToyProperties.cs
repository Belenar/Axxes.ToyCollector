using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.ToyCollector.Migrations.EFCore.Migrations
{
    public partial class AddSomeToyProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcquiredCondition",
                table: "Toys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcquiredDate",
                table: "Toys",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentCondition",
                table: "Toys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcquiredCondition",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "AcquiredDate",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "CurrentCondition",
                table: "Toys");
        }
    }
}
