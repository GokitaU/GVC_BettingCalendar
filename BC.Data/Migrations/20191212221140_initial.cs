using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BC.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: false),
                    OddsForFirstTeam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OddsForDraw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OddsForSecondTeam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventStartDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
