using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOCPLWebApplication.Migrations
{
    public partial class ChangingTableDataVMProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableDataVM_Products_TableProductsId",
                table: "TableDataVM");

            migrationBuilder.DropForeignKey(
                name: "FK_TableDataVM_Servers_TableServersId",
                table: "TableDataVM");

            migrationBuilder.RenameColumn(
                name: "TableServersId",
                table: "TableDataVM",
                newName: "TableServerId");

            migrationBuilder.RenameColumn(
                name: "TableProductsId",
                table: "TableDataVM",
                newName: "TableProductId");

            migrationBuilder.RenameIndex(
                name: "IX_TableDataVM_TableServersId",
                table: "TableDataVM",
                newName: "IX_TableDataVM_TableServerId");

            migrationBuilder.RenameIndex(
                name: "IX_TableDataVM_TableProductsId",
                table: "TableDataVM",
                newName: "IX_TableDataVM_TableProductId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableDataVM_Products_TableProductId",
                table: "TableDataVM");

            migrationBuilder.DropForeignKey(
                name: "FK_TableDataVM_Servers_TableServerId",
                table: "TableDataVM");

            migrationBuilder.RenameColumn(
                name: "TableServerId",
                table: "TableDataVM",
                newName: "TableServersId");

            migrationBuilder.RenameColumn(
                name: "TableProductId",
                table: "TableDataVM",
                newName: "TableProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_TableDataVM_TableServerId",
                table: "TableDataVM",
                newName: "IX_TableDataVM_TableServersId");

            migrationBuilder.RenameIndex(
                name: "IX_TableDataVM_TableProductId",
                table: "TableDataVM",
                newName: "IX_TableDataVM_TableProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TableDataVM_Products_TableProductsId",
                table: "TableDataVM",
                column: "TableProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TableDataVM_Servers_TableServersId",
                table: "TableDataVM",
                column: "TableServersId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
