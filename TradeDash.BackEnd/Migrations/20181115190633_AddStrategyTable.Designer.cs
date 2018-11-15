﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeDash.BackEnd.Models;

namespace TradeDash.BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181115190633_AddStrategyTable")]
    partial class AddStrategyTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradeDash.BackEnd.Models.MoneyManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountValue");

                    b.Property<decimal>("AmountAvIfAllBought");

                    b.Property<string>("Name");

                    b.Property<decimal>("ToBuyAll");

                    b.HasKey("Id");

                    b.ToTable("MoneyManagements");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MoneyManagementId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MoneyManagementId");

                    b.ToTable("Strategies");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.Strategy", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Models.MoneyManagement", "MoneyManagement")
                        .WithMany()
                        .HasForeignKey("MoneyManagementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
