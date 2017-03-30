using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NOCPLWebApplication.Migrations
{
    public partial class ChaningTableDataVMProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableDataVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableProductsId = table.Column<int>(nullable: true),
                    TableServersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDataVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableDataVM_Products_TableProductsId",
                        column: x => x.TableProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TableDataVM_Servers_TableServersId",
                        column: x => x.TableServersId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableDataVM_TableProductsId",
                table: "TableDataVM",
                column: "TableProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TableDataVM_TableServersId",
                table: "TableDataVM",
                column: "TableServersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableDataVM");
        }
    }
}
