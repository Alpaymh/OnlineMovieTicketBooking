﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineMovieTicketBooking.Data;

#nullable disable

namespace OnlineMovieTicketBooking.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230820214908_9_mig")]
    partial class _9_mig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("Dil")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FilmAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriID")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriID");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RolAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Seans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("time");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("SalonId");

                    b.ToTable("Seanslar");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.SinemaSalonu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("PopulerSalon")
                        .HasColumnType("bit");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalonAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("SinemaSalonlari");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Siparis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("SatinAlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeansID")
                        .HasColumnType("int");

                    b.Property<int>("UyeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeansID");

                    b.HasIndex("UyeID");

                    b.ToTable("Siparişler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Uye", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Kilit")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProfilResimDosyası")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RolID")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("RolID");

                    b.ToTable("Uyeler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Film", b =>
                {
                    b.HasOne("OnlineMovieTicketBooking.Entities.Kategori", "Kategori")
                        .WithMany("Filmler")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Seans", b =>
                {
                    b.HasOne("OnlineMovieTicketBooking.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMovieTicketBooking.Entities.SinemaSalonu", "Salon")
                        .WithMany("Seanslar")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Siparis", b =>
                {
                    b.HasOne("OnlineMovieTicketBooking.Entities.Seans", "Seans")
                        .WithMany("Siparişler")
                        .HasForeignKey("SeansID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMovieTicketBooking.Entities.Uye", "Uye")
                        .WithMany("Siparişler")
                        .HasForeignKey("UyeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seans");

                    b.Navigation("Uye");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Uye", b =>
                {
                    b.HasOne("OnlineMovieTicketBooking.Entities.Rol", "Rol")
                        .WithMany("Uyeler")
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Kategori", b =>
                {
                    b.Navigation("Filmler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Rol", b =>
                {
                    b.Navigation("Uyeler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Seans", b =>
                {
                    b.Navigation("Siparişler");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.SinemaSalonu", b =>
                {
                    b.Navigation("Seanslar");
                });

            modelBuilder.Entity("OnlineMovieTicketBooking.Entities.Uye", b =>
                {
                    b.Navigation("Siparişler");
                });
#pragma warning restore 612, 618
        }
    }
}
