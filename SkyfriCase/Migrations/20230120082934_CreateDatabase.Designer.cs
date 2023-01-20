﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkyfriCase.Context;

#nullable disable

namespace SkyfriCase.Migrations
{
    [DbContext(typeof(SkyfriDbContext))]
    [Migration("20230120082934_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkyfriCase.Models.Portfolio", b =>
                {
                    b.Property<Guid>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PortfolioName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PortfolioId");

                    b.HasIndex("TenantId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("SkyfriCase.Models.Tenant", b =>
                {
                    b.Property<Guid>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("SkyfriCase.Models.Portfolio", b =>
                {
                    b.HasOne("SkyfriCase.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
