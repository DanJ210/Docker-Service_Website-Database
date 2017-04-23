using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NocWebUtilityApp.Models;

namespace NocWebUtilityApp.Migrations
{
    [DbContext(typeof(ProductLocationContext))]
    [Migration("20170411193332_RestoringDatabaseWithIdentity")]
    partial class RestoringDatabaseWithIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NocWebUtilityApp.Models.Product", b =>
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

            modelBuilder.Entity("NocWebUtilityApp.Models.Server", b =>
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

            modelBuilder.Entity("NocWebUtilityApp.Models.TableDataVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("TableDataVM");
                });

            modelBuilder.Entity("NocWebUtilityApp.Models.Product", b =>
                {
                    b.HasOne("NocWebUtilityApp.Models.Server", "PrimaryProductServer")
                        .WithMany()
                        .HasForeignKey("PrimaryProductServerId");

                    b.HasOne("NocWebUtilityApp.Models.Server", "SecondaryProductServer")
                        .WithMany()
                        .HasForeignKey("SecondaryProductServerId");

                    b.HasOne("NocWebUtilityApp.Models.TableDataVM")
                        .WithMany("TableProducts")
                        .HasForeignKey("TableDataVMId");
                });

            modelBuilder.Entity("NocWebUtilityApp.Models.Server", b =>
                {
                    b.HasOne("NocWebUtilityApp.Models.TableDataVM")
                        .WithMany("TableServers")
                        .HasForeignKey("TableDataVMId");
                });
        }
    }
}
