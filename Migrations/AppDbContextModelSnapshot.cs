﻿// <auto-generated />
using System;
using ArtWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ArtWebApi.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GalleryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ArtistId");

                    b.HasIndex("GalleryId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            GalleryId = 1,
                            Name = "Artist 1"
                        },
                        new
                        {
                            ArtistId = 2,
                            GalleryId = 1,
                            Name = "Artist 2"
                        },
                        new
                        {
                            ArtistId = 3,
                            GalleryId = 2,
                            Name = "Artist 3"
                        });
                });

            modelBuilder.Entity("ArtWebApi.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GalleryId");

                    b.ToTable("Galleries");

                    b.HasData(
                        new
                        {
                            GalleryId = 1,
                            Name = "Gallery 1"
                        },
                        new
                        {
                            GalleryId = 2,
                            Name = "Gallery 2"
                        });
                });

            modelBuilder.Entity("ArtWebApi.Models.Artist", b =>
                {
                    b.HasOne("ArtWebApi.Models.Gallery", "Gallery")
                        .WithMany("Artists")
                        .HasForeignKey("GalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("ArtWebApi.Models.Gallery", b =>
                {
                    b.Navigation("Artists");
                });
#pragma warning restore 612, 618
        }
    }
}
