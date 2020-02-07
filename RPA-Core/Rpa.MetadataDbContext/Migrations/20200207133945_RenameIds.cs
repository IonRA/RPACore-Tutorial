using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rpa.MetadataDbContext.Migrations
{
    public partial class RenameIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CloseAppComponents");

            migrationBuilder.DropTable(
                name: "OpenAppComponents");

            migrationBuilder.DropTable(
                name: "SaveAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WriteAppComponents",
                table: "WriteAppComponents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WriteAppComponents");

            migrationBuilder.DropColumn(
                name: "IdSolution",
                table: "WriteAppComponents");

            migrationBuilder.RenameTable(
                name: "WriteAppComponents",
                newName: "Component");

            migrationBuilder.AlterColumn<int>(
                name: "PID",
                table: "Component",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentId",
                table: "Component",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Component",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Component",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SolutionID",
                table: "Component",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AppName",
                table: "Component",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseShell",
                table: "Component",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Component",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Component",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WriteApp_PID",
                table: "Component",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Component",
                table: "Component",
                column: "ComponentId");

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Component_SolutionID",
                table: "Component",
                column: "SolutionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Solutions_SolutionID",
                table: "Component",
                column: "SolutionID",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Component_Solutions_SolutionID",
                table: "Component");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Component",
                table: "Component");

            migrationBuilder.DropIndex(
                name: "IX_Component_SolutionID",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "SolutionID",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "AppName",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "UseShell",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "WriteApp_PID",
                table: "Component");

            migrationBuilder.RenameTable(
                name: "Component",
                newName: "WriteAppComponents");

            migrationBuilder.AlterColumn<int>(
                name: "PID",
                table: "WriteAppComponents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WriteAppComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdSolution",
                table: "WriteAppComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WriteAppComponents",
                table: "WriteAppComponents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CloseAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolution = table.Column<int>(type: "int", nullable: false),
                    PID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseAppComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSolution = table.Column<int>(type: "int", nullable: false),
                    UseShell = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAppComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaveAppComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolution = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveAppComponents", x => x.Id);
                });
        }
    }
}
