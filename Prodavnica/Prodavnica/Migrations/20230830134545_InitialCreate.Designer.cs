﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prodavnica.Data;

#nullable disable

namespace Prodavnica.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230830134545_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prodavnica.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Tip")
                        .HasColumnType("int");

                    b.Property<int>("Verifikacija")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Korisniks");
                });

            modelBuilder.Entity("Prodavnica.Models.Porudzbina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("CenaZaDostavu")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VremeDostave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremeNarudzbine")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Porudzbinas");
                });

            modelBuilder.Entity("Prodavnica.Models.PorudzbinaProizvod", b =>
                {
                    b.Property<int>("NarudzbinaId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.HasKey("NarudzbinaId", "ProizvodId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("PorudzbinaProizvods");
                });

            modelBuilder.Entity("Prodavnica.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Obrisan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Proizvods");
                });

            modelBuilder.Entity("Prodavnica.Models.Porudzbina", b =>
                {
                    b.HasOne("Prodavnica.Models.Korisnik", "Korisnik")
                        .WithMany("Porudzbinas")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("Prodavnica.Models.PorudzbinaProizvod", b =>
                {
                    b.HasOne("Prodavnica.Models.Porudzbina", "Porudzbina")
                        .WithMany("PorudzbinaProizvods")
                        .HasForeignKey("NarudzbinaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Prodavnica.Models.Proizvod", "Proizvod")
                        .WithMany("PorudzbinaProizvods")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Porudzbina");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("Prodavnica.Models.Proizvod", b =>
                {
                    b.HasOne("Prodavnica.Models.Korisnik", "Korisnik")
                        .WithMany("Proizvods")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("Prodavnica.Models.Korisnik", b =>
                {
                    b.Navigation("Porudzbinas");

                    b.Navigation("Proizvods");
                });

            modelBuilder.Entity("Prodavnica.Models.Porudzbina", b =>
                {
                    b.Navigation("PorudzbinaProizvods");
                });

            modelBuilder.Entity("Prodavnica.Models.Proizvod", b =>
                {
                    b.Navigation("PorudzbinaProizvods");
                });
#pragma warning restore 612, 618
        }
    }
}