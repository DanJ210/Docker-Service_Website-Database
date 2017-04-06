using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOCPLWebApplication.Migrations
{
    public partial class ProductEntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Servers_ProductServerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductServerId",
                table: "Products",
                newName: "SecondaryProductServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductServerId",
                table: "Products",
                newName: "IX_Products_SecondaryProductServerId");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryProductServerId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PrimaryProductServerId",
                table: "Products",
                column: "PrimaryProductServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Servers_PrimaryProductServerId",
                table: "Products",
                column: "PrimaryProductServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Servers_SecondaryProductServerId",
                table: "Products",
                column: "SecondaryProductServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Servers_PrimaryProductServerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Servers_SecondaryProductServerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PrimaryProductServerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PrimaryProductServerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SecondaryProductServerId",
                table: "Products",
                newName: "ProductServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SecondaryProductServerId",
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
    }
}
