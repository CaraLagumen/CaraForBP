﻿// <auto-generated />
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(PaymentDetailContext))]
    [Migration("20200707012443_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.PaymentDetail", b =>
                {
                    b.Property<int>("PMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CardOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CardOwnerStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardOwnerZip")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("ProcessedAmount")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProcessorResponse")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RequestedAmount")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TransactionAmount")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(10)");

                    b.HasKey("PMId");

                    b.ToTable("PaymentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
