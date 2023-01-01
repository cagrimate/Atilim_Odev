﻿// <auto-generated />
using System;
using Atilim_Odev.Models.Siniflar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atilim_Odev.Migrations
{
    [DbContext(typeof(AtilimContext))]
    partial class AtilimContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Ders_Kayit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DersId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("Ders_Kayit");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Dersler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DersAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DersKodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<int>("Kredi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Iletisim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GSM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Il")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Iletisim");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Kimlik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DogumYeri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IletisimId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TC_No")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IletisimId");

                    b.ToTable("Kimlik");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Kullanicilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kullanici_Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tur")
                        .HasColumnType("int");

                    b.Property<int>("kimlikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kimlikId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Mufredat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MufredatAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mufredatlar");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KimlikId")
                        .HasColumnType("int");

                    b.Property<int>("MufredatId")
                        .HasColumnType("int");

                    b.Property<int>("Ogr_No")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KimlikId");

                    b.HasIndex("MufredatId");

                    b.ToTable("Ogrenci");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rol_Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("DerslerMufredat", b =>
                {
                    b.Property<int>("DerslerId")
                        .HasColumnType("int");

                    b.Property<int>("MufredatId")
                        .HasColumnType("int");

                    b.HasKey("DerslerId", "MufredatId");

                    b.HasIndex("MufredatId");

                    b.ToTable("DerslerMufredat");
                });

            modelBuilder.Entity("KullanicilarRol", b =>
                {
                    b.Property<int>("KullanicilarId")
                        .HasColumnType("int");

                    b.Property<int>("RollerId")
                        .HasColumnType("int");

                    b.HasKey("KullanicilarId", "RollerId");

                    b.HasIndex("RollerId");

                    b.ToTable("KullanicilarRol");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Ders_Kayit", b =>
                {
                    b.HasOne("Atilim_Odev.Models.Siniflar.Dersler", "Ders")
                        .WithMany()
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atilim_Odev.Models.Siniflar.Ogrenci", "Ogrenci")
                        .WithMany()
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Kimlik", b =>
                {
                    b.HasOne("Atilim_Odev.Models.Siniflar.Iletisim", "Iletisim")
                        .WithMany()
                        .HasForeignKey("IletisimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iletisim");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Kullanicilar", b =>
                {
                    b.HasOne("Atilim_Odev.Models.Siniflar.Kimlik", "kimlik")
                        .WithMany()
                        .HasForeignKey("kimlikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kimlik");
                });

            modelBuilder.Entity("Atilim_Odev.Models.Siniflar.Ogrenci", b =>
                {
                    b.HasOne("Atilim_Odev.Models.Siniflar.Kimlik", "Kimlik")
                        .WithMany()
                        .HasForeignKey("KimlikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atilim_Odev.Models.Siniflar.Mufredat", "Mufredat")
                        .WithMany()
                        .HasForeignKey("MufredatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kimlik");

                    b.Navigation("Mufredat");
                });

            modelBuilder.Entity("DerslerMufredat", b =>
                {
                    b.HasOne("Atilim_Odev.Models.Siniflar.Dersler", null)
                        .WithMany()
                        .HasForeignKey("DerslerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atilim_Odev.Models.Siniflar.Mufredat", null)
                        .WithMany()
                        .HasForeignKey("MufredatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KullanicilarRol", b =>
                {
                    b.HasOne("Atilim_Odev.Models.Siniflar.Kullanicilar", null)
                        .WithMany()
                        .HasForeignKey("KullanicilarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atilim_Odev.Models.Siniflar.Rol", null)
                        .WithMany()
                        .HasForeignKey("RollerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
