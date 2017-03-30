using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NOCPLWebApplication.Models;

namespace NOCPLWebApplication.Migrations
{
    [DbContext(typeof(ProductLocationContext))]
    [Migration("20170330154917_ChaningTableDataVMProperties")]
    partial class ChaningTableDataVMProperties
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

                    b.Property<int?>("TableProductsId");

                    b.Property<int?>("TableServersId");

                    b.HasKey("Id");

                    b.HasIndex("TableProductsId");

                    b.HasIndex("TableServersId");

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
                    b.HasOne("NOCPLWebApplication.Models.Product", "TableProducts")
                        .WithMany()
                        .HasForeignKey("TableProductsId");

                    b.HasOne("NOCPLWebApplication.Models.Server", "TableServers")
                        .WithMany()
                        .HasForeignKey("TableServersId");
                });
        }
    }
}
