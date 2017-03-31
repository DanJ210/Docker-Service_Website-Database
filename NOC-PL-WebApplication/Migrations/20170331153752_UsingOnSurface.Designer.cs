using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NOCPLWebApplication.Models;

namespace NOCPLWebApplication.Migrations
{
    [DbContext(typeof(ProductLocationContext))]
    [Migration("20170331153752_UsingOnSurface")]
    partial class UsingOnSurface
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

                    b.Property<int?>("TableDataVMId");

                    b.Property<int>("TableNumber");

                    b.HasKey("Id");

                    b.HasIndex("ProductServerId");

                    b.HasIndex("TableDataVMId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ServerGroup");

                    b.Property<string>("ServerName");

                    b.Property<int?>("TableDataVMId");

                    b.Property<int>("TableNumber");

                    b.HasKey("Id");

                    b.HasIndex("TableDataVMId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.TableDataVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("TableDataVM");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Product", b =>
                {
                    b.HasOne("NOCPLWebApplication.Models.Server", "ProductServer")
                        .WithMany()
                        .HasForeignKey("ProductServerId");

                    b.HasOne("NOCPLWebApplication.Models.TableDataVM")
                        .WithMany("TableProduct")
                        .HasForeignKey("TableDataVMId");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Server", b =>
                {
                    b.HasOne("NOCPLWebApplication.Models.TableDataVM")
                        .WithMany("TableServer")
                        .HasForeignKey("TableDataVMId");
                });
        }
    }
}
