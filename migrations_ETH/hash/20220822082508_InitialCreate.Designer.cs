﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace test_wd_bots.migrations_ETH.hash
{
    [DbContext(typeof(Transaction_DB_eth))]
    [Migration("20220822082508_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Transaction_Logs", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CallHashFrom")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("address")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("blockHash")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("blockNumber")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("data")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("logIndex")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("transactionHash")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("transactionIndex")
                        .HasColumnType("varchar(1024)");

                    b.HasKey("id");

                    b.ToTable("transaction_data");
                });
#pragma warning restore 612, 618
        }
    }
}
