using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NOCPLWebApplication.Models;

namespace NOCPLWebApplication.Migrations
{
    [DbContext(typeof(ProductLocationContext))]
    [Migration("20170322191411_DatabaseCreation")]
    partial class DatabaseCreation
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

                    b.Property<string>("ProductName");

                    b.Property<int?>("ServerId");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ServerName");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("NOCPLWebApplication.Models.Product", b =>
                {
                    b.HasOne("NOCPLWebApplication.Models.Server")
                        .WithMany("ProductsContained")
                        .HasForeignKey("ServerId");
                });
        }
    }
}
