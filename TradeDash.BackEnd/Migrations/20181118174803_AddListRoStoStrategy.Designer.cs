﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeDash.BackEnd.Models;

namespace TradeDash.BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181118174803_AddListRoStoStrategy")]
    partial class AddListRoStoStrategy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradeDash.BackEnd.Models.EstaminateReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AccountValue");

                    b.Property<double>("Percentage");

                    b.Property<double>("Premium");

                    b.HasKey("Id");

                    b.ToTable("EstaminateReturns");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.MoneyManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountValue")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal>("AmountAvIfAllBought")
                        .HasColumnType("decimal(9,6)");

                    b.Property<string>("Name");

                    b.Property<decimal>("ToBuyAll")
                        .HasColumnType("decimal(9,6)");

                    b.HasKey("Id");

                    b.ToTable("MoneyManagements");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.ReturnOnStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AtTheEndProfit");

                    b.Property<double>("DrawDown");

                    b.Property<double>("ProfitLoss");

                    b.Property<int?>("StrategyId");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId");

                    b.ToTable("ReturnOnStrategies");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstaminateReturnId");

                    b.Property<int>("MoneyManagementId");

                    b.Property<int>("StrategyType");

                    b.HasKey("Id");

                    b.HasIndex("EstaminateReturnId");

                    b.HasIndex("MoneyManagementId");

                    b.ToTable("Strategies");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.ReturnOnStrategy", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Models.Strategy")
                        .WithMany("ReturnOnStrategy")
                        .HasForeignKey("StrategyId");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Models.Strategy", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Models.EstaminateReturn", "EstaminateReturn")
                        .WithMany()
                        .HasForeignKey("EstaminateReturnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TradeDash.BackEnd.Models.MoneyManagement", "MoneyManagement")
                        .WithMany()
                        .HasForeignKey("MoneyManagementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
