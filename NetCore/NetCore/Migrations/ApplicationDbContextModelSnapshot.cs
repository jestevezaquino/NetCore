﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Services;

namespace NetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(17);

                    b.Property<int>("Amount")
                        .HasColumnName("Cantidad");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Descripcion");

                    b.Property<int>("Genre")
                        .HasColumnName("Genero");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnName("Foto");

                    b.Property<decimal>("Price")
                        .HasColumnName("Precio")
                        .HasColumnType("decimal");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Tituto");

                    b.HasKey("ISBN");

                    b.ToTable("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}