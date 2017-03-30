using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOCPLWebApplication.Migrations
{
    public partial class ChangesToEntityModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Servers_ServerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ServerId",
                table: "Products",
                newName: "ProductServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ServerId",
                table: "Products",
                newName: "IX_Products_ProductServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Servers_ProductServerId",
                table: "Products",
                column: "ProductServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Servers_ProductServerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductServerId",
                table: "Products",
                newName: "ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductServerId",
                table: "Products",
                newName: "IX_Products_ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Servers_ServerId",
                table: "Products",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
