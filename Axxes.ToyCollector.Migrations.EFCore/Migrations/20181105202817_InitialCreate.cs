using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.ToyCollector.Migrations.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    SetNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Unopened = table.Column<bool>(nullable: true),
                    FinishedBuildDate = table.Column<DateTime>(type: "date", nullable: true),
                    Diameter = table.Column<int>(nullable: true),
                    Transparent = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toys");
        }
    }
}
