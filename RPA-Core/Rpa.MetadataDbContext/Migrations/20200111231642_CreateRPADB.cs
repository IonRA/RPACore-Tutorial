using Microsoft.EntityFrameworkCore.Migrations;

namespace Rpa.MetadataDbContext.Migrations
{
    public partial class CreateRPADB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CloseAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolution = table.Column<int>(nullable: false),
                    PID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseAppComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolution = table.Column<int>(nullable: false),
                    AppName = table.Column<string>(nullable: true),
                    UseShell = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAppComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaveAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolution = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveAppComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WriteAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolution = table.Column<int>(nullable: false),
                    PID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteAppComponents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CloseAppComponents");

            migrationBuilder.DropTable(
                name: "OpenAppComponents");

            migrationBuilder.DropTable(
                name: "SaveAppComponents");

            migrationBuilder.DropTable(
                name: "WriteAppComponents");
        }
    }
}
