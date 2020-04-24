using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracker.Data.Migrations
{
    public partial class RealCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealCase",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Cases = table.Column<int>(nullable: false),
                    Recorvered = table.Column<int>(nullable: false),
                    Sick = table.Column<int>(nullable: false),
                    Death = table.Column<int>(nullable: false),
                    Tested = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealCase", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealCase");
        }
    }
}
