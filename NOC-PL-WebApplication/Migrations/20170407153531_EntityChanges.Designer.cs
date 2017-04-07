using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NOCPLWebApplication.Models;

namespace NOCPLWebApplication.Migrations
{
    [DbContext(typeof(ProductLocationContext))]
    [Migration("20170407153531_EntityChanges")]
    partial class EntityChanges
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

                    b.Property<int?>("PrimaryProductServerId");

                    b.Property<string>("ProductGroup");

                    b.Property<string>("ProductName");

                    b.Property<int?>("SecondaryProductServerId");

                    b.Property<int?>("TableDataVMId");

                    b.Property<int>("TableNumber");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryProductServerId");

                    b.HasIndex("SecondaryProductServerId");

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
                    b.HasOne("NOCPLWebApplication.Models.Server", "PrimaryProductServer")
                        .WithMany()
                        .HasForeignKey("PrimaryProductServerId");

                    b.HasOne("NOCPLWebApplication.Models.Server", "SecondaryProductServer")
                        .WithMany()
                        .HasForeignKey("SecondaryProductServerId");

                    b.HasOne("NOCPLWebApplication.Models.TableDataVM")
                        .WithMany("TableProducts")
                        .HasForeignKey("TableDataVMId");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Server", b =>
                {
                    b.HasOne("NOCPLWebApplication.Models.TableDataVM")
                        .WithMany("TableServers")
                        .HasForeignKey("TableDataVMId");
                });
        }
    }
}
