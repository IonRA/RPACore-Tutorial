using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rpa.MetadataDbContext.Migrations
{
    public partial class ChangeIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WriteAppComponents",
                table: "WriteAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveAppComponents",
                table: "SaveAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenAppComponents",
                table: "OpenAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CloseAppComponents",
                table: "CloseAppComponents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WriteAppComponents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SaveAppComponents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OpenAppComponents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CloseAppComponents");

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentId",
                table: "WriteAppComponents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentId",
                table: "SaveAppComponents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentId",
                table: "OpenAppComponents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ComponentId",
                table: "CloseAppComponents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WriteAppComponents",
                table: "WriteAppComponents",
                column: "ComponentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveAppComponents",
                table: "SaveAppComponents",
                column: "ComponentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenAppComponents",
                table: "OpenAppComponents",
                column: "ComponentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CloseAppComponents",
                table: "CloseAppComponents",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WriteAppComponents",
                table: "WriteAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveAppComponents",
                table: "SaveAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenAppComponents",
                table: "OpenAppComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CloseAppComponents",
                table: "CloseAppComponents");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "WriteAppComponents");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "SaveAppComponents");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "OpenAppComponents");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "CloseAppComponents");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WriteAppComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SaveAppComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OpenAppComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CloseAppComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WriteAppComponents",
                table: "WriteAppComponents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveAppComponents",
                table: "SaveAppComponents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenAppComponents",
                table: "OpenAppComponents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CloseAppComponents",
                table: "CloseAppComponents",
                column: "Id");
        }
    }
}
