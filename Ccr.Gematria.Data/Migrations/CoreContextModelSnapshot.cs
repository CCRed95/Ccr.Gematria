﻿// <auto-generated />
using Ccr.Gematria.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ccr.Gematria.Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    partial class CoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ccr.Gematria.Data.Domain.GematriaResult", b =>
                {
                    b.Property<int>("GematriaResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnglishOrdinal")
                        .HasColumnType("int");

                    b.Property<int>("FibonacciSequence")
                        .HasColumnType("int");

                    b.Property<int>("FullReduction")
                        .HasColumnType("int");

                    b.Property<int>("Jewish")
                        .HasColumnType("int");

                    b.Property<int>("ReverseFullReduction")
                        .HasColumnType("int");

                    b.Property<int>("ReverseOrdinal")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("GematriaResultID");

                    b.ToTable("GematriaResults");
                });
#pragma warning restore 612, 618
        }
    }
}