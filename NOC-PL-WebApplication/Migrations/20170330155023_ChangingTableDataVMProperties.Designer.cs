using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NOCPLWebApplication.Models;

namespace NOCPLWebApplication.Migrations
{
    [DbContext(typeof(ProductLocationContext))]
    [Migration("20170330155023_ChangingTableDataVMProperties")]
    partial class ChangingTableDataVMProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NOCPLWebApplication.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductGroup");

                    b.Property<string>("ProductName");

                    b.Property<int?>("ProductServerId");

                    b.Property<int>("TableNumber");

                    b.HasKey("Id");

                    b.HasIndex("ProductServerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ServerGroup");

                    b.Property<string>("ServerName");

                    b.Property<int>("TableNumber");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.TableDataVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TableProductId");

                    b.Property<int?>("TableServerId");

                    b.HasKey("Id");

                    b.HasIndex("TableProductId");

                    b.HasIndex("TableServerId");

                    b.ToTable("TableDataVM");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Product", b =>
                {
                    b.HasOne("NOCPLWebApplication.Models.Server", "ProductServer")
                        .WithMany("ProductsContained")
                        .HasForeignKey("ProductServerId");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.TableDataVM", b =>
                {
                    b.HasOne("NOCPLWebApplication.Models.Product", "TableProduct")
                        .WithMany()
                        .HasForeignKey("TableProductId");

                    b.HasOne("NOCPLWebApplication.Models.Server", "TableServer")
                        .WithMany()
                        .HasForeignKey("TableServerId");
                });
        }
    }
}
