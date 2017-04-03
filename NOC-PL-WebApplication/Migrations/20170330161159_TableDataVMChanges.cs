using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOCPLWebApplication.Migrations
{
    public partial class TableDataVMChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableDataVM_Products_TableProductId",
                table: "TableDataVM");

            migrationBuilder.DropForeignKey(
                name: "FK_TableDataVM_Servers_TableServerId",
                table: "TableDataVM");

            migrationBuilder.DropIndex(
                name: "IX_TableDataVM_TableProductId",
                table: "TableDataVM");

            migrationBuilder.DropIndex(
                name: "IX_TableDataVM_TableServerId",
                table: "TableDataVM");

            migrationBuilder.DropColumn(
                name: "TableProductId",
                table: "TableDataVM");

            migrationBuilder.DropColumn(
                name: "TableServerId",
                table: "TableDataVM");

            migrationBuilder.AddColumn<int>(
                name: "TableDataVMId",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableDataVMId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servers_TableDataVMId",
                table: "Servers",
                column: "TableDataVMId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TableDataVMId",
                table: "Products",
                column: "TableDataVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TableDataVM_TableDataVMId",
                table: "Products",
                column: "TableDataVMId",
                principalTable: "TableDataVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_TableDataVM_TableDataVMId",
                table: "Servers",
                column: "TableDataVMId",
                principalTable: "TableDataVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TableDataVM_TableDataVMId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Servers_TableDataVM_TableDataVMId",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Servers_TableDataVMId",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Products_TableDataVMId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TableDataVMId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "TableDataVMId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "TableProductId",
                table: "TableDataVM",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableServerId",
                table: "TableDataVM",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableDataVM_TableProductId",
                table: "TableDataVM",
                column: "TableProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataVM_TableServerId",
                table: "TableDataVM",
                column: "TableServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TableDataVM_Products_TableProductId",
                table: "TableDataVM",
                column: "TableProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TableDataVM_Servers_TableServerId",
                table: "TableDataVM",
                column: "TableServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
