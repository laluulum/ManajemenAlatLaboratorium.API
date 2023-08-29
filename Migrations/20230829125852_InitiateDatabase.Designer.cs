﻿// <auto-generated />
using System;
using ManajemenAlatLaboratorium.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManajemenAlatLaboratorium.API.Migrations
{
    [DbContext(typeof(LaboratoriumContext))]
    [Migration("20230829125852_InitiateDatabase")]
    partial class InitiateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.Alat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Deskripsi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int>("Total")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Alats");
                });

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.Peminjam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aktif")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("NomorHandphone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Peminjams");
                });

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.PeminjamanAlat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DikembalikanPadaTanggal")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeminjamId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TanggalPeminjaman")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TanggalPengembalian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PeminjamId");

                    b.ToTable("PeminjamanAlats");
                });

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.PeminjamanAlatDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlatId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Jumlah")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PeminjamanAlatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlatId");

                    b.HasIndex("PeminjamanAlatId");

                    b.ToTable("PeminjamanAlatDetails");
                });

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.PeminjamanAlat", b =>
                {
                    b.HasOne("ManajemenAlatLaboratorium.API.Models.Peminjam", "Peminjam")
                        .WithMany()
                        .HasForeignKey("PeminjamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peminjam");
                });

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.PeminjamanAlatDetail", b =>
                {
                    b.HasOne("ManajemenAlatLaboratorium.API.Models.Alat", "Alat")
                        .WithMany()
                        .HasForeignKey("AlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManajemenAlatLaboratorium.API.Models.PeminjamanAlat", null)
                        .WithMany("Details")
                        .HasForeignKey("PeminjamanAlatId");

                    b.Navigation("Alat");
                });

            modelBuilder.Entity("ManajemenAlatLaboratorium.API.Models.PeminjamanAlat", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
