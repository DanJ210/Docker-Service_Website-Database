using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NocWebUtilityApp.Migrations
{
    public partial class AddingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineText",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineText",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Products");
        }
    }
}
