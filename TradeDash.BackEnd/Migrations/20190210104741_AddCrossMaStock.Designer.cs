﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeDash.BackEnd.Data;

namespace TradeDash.BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190210104741_AddCrossMaStock")]
    partial class AddCrossMaStock
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradeDash.BackEnd.Data.CrossMaStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Change");

                    b.Property<double>("ChangeOverTime");

                    b.Property<double>("ChangePercent");

                    b.Property<double>("Close");

                    b.Property<int>("CrossMaStrategyId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("High");

                    b.Property<string>("History");

                    b.Property<string>("Label");

                    b.Property<double>("LongSma");

                    b.Property<double>("Low");

                    b.Property<int>("Number");

                    b.Property<double>("Open");

                    b.Property<string>("Ticker");

                    b.Property<long>("UnadjustedVolume");

                    b.Property<long>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CrossMaStrategyId");

                    b.ToTable("CrossMaStocks");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.EstaminateReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AccountValue");

                    b.Property<double>("Percentage");

                    b.Property<double>("Premium");

                    b.Property<int?>("StrategyId");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId");

                    b.ToTable("EstaminateReturns");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.MoneyManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountValue")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal>("AmountAvIfAllBought")
                        .HasColumnType("decimal(9,6)");

                    b.Property<int?>("StrategyId");

                    b.Property<decimal>("ToBuyAll")
                        .HasColumnType("decimal(9,6)");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId")
                        .IsUnique()
                        .HasFilter("[StrategyId] IS NOT NULL");

                    b.ToTable("MoneyManagements");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.OptionTrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Commissions");

                    b.Property<double>("Contracts");

                    b.Property<double>("CurrentPrice");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<double>("LossPremium");

                    b.Property<double>("Margin");

                    b.Property<double>("NeededInReserve");

                    b.Property<string>("OptionType");

                    b.Property<double>("Premium");

                    b.Property<double>("PremiumAfterCommissions");

                    b.Property<int?>("StrategyId");

                    b.Property<double>("Strike");

                    b.Property<string>("Ticker");

                    b.HasKey("Id");

                    b.ToTable("OptionTrades");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.ReturnOnStrategy", b =>
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

            modelBuilder.Entity("TradeDash.BackEnd.Data.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Change");

                    b.Property<double>("ChangeOverTime");

                    b.Property<double>("ChangePercent");

                    b.Property<double>("Close");

                    b.Property<DateTime>("Date");

                    b.Property<double>("High");

                    b.Property<string>("History");

                    b.Property<string>("Label");

                    b.Property<double>("Low");

                    b.Property<int>("Number");

                    b.Property<double>("Open");

                    b.Property<string>("Ticker");

                    b.Property<long>("UnadjustedVolume");

                    b.Property<long>("Volume");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.StockTrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CurrentPrice");

                    b.Property<DateTime>("Date");

                    b.Property<double>("PL");

                    b.Property<int>("Quantity");

                    b.Property<int?>("StrategyId");

                    b.Property<double>("StrikePrice");

                    b.Property<string>("Ticker");

                    b.HasKey("Id");

                    b.ToTable("StockTrades");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<int>("StrategyType");

                    b.HasKey("Id");

                    b.ToTable("Strategies");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Strategy");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.CrossMaStrategy", b =>
                {
                    b.HasBaseType("TradeDash.BackEnd.Data.Strategy");

                    b.HasDiscriminator().HasValue("CrossMaStrategy");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.CrossMaStock", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Data.CrossMaStrategy", "CrossMaStrategy")
                        .WithMany("Stocks")
                        .HasForeignKey("CrossMaStrategyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.EstaminateReturn", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Data.Strategy")
                        .WithMany("EstaminateReturns")
                        .HasForeignKey("StrategyId");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.MoneyManagement", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Data.Strategy")
                        .WithOne("MoneyManagement")
                        .HasForeignKey("TradeDash.BackEnd.Data.MoneyManagement", "StrategyId");
                });

            modelBuilder.Entity("TradeDash.BackEnd.Data.ReturnOnStrategy", b =>
                {
                    b.HasOne("TradeDash.BackEnd.Data.Strategy")
                        .WithMany("ReturnOnStrategy")
                        .HasForeignKey("StrategyId");
                });
#pragma warning restore 612, 618
        }
    }
}
