﻿// <auto-generated />
using System;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210124013848_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("InventorySystem.Models.ComputerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComputerTypes");
                });

            modelBuilder.Entity("InventorySystem.Models.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComputerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FromFactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RamSlots")
                        .HasColumnType("int");

                    b.Property<string>("ScreenSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsbPorts")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComputerTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("InventorySystem.Models.Properties", b =>
                {
                    b.HasOne("InventorySystem.Models.ComputerType", "ComputerType")
                        .WithMany()
                        .HasForeignKey("ComputerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComputerType");
                });
#pragma warning restore 612, 618
        }
    }
}
