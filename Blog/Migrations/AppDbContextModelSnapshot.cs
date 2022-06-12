﻿// <auto-generated />
using System;
using Blog.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Models.BlogCurtida", b =>
                {
                    b.Property<int>("CurtidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCurtida")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Like")
                        .HasColumnType("bit");

                    b.HasKey("CurtidaId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogCurtidas");
                });

            modelBuilder.Entity("Blog.Models.BlogImagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ImagemId");

                    b.ToTable("BlogImagems");
                });

            modelBuilder.Entity("Blog.Models.BlogM", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImagemId")
                        .HasColumnType("int");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.HasIndex("ImagemId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Blog.Models.BlogCurtida", b =>
                {
                    b.HasOne("Blog.Models.BlogM", "Blog")
                        .WithMany("Curtidas")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Blog.Models.BlogM", b =>
                {
                    b.HasOne("Blog.Models.BlogImagem", "Image")
                        .WithMany()
                        .HasForeignKey("ImagemId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Blog.Models.BlogM", b =>
                {
                    b.Navigation("Curtidas");
                });
#pragma warning restore 612, 618
        }
    }
}