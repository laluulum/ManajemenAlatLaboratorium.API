using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManajemenAlatLaboratorium.API.Migrations
{
    /// <inheritdoc />
    public partial class InitiateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nama = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Deskripsi = table.Column<string>(type: "TEXT", nullable: true),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peminjams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nama = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Alamat = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NomorHandphone = table.Column<string>(type: "TEXT", nullable: false),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peminjams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeminjamanAlats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TanggalPeminjaman = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TanggalPengembalian = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DikembalikanPadaTanggal = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PeminjamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeminjamanAlats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeminjamanAlats_Peminjams_PeminjamId",
                        column: x => x.PeminjamId,
                        principalTable: "Peminjams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeminjamanAlatDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlatId = table.Column<int>(type: "INTEGER", nullable: false),
                    Jumlah = table.Column<int>(type: "INTEGER", nullable: false),
                    PeminjamanAlatId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeminjamanAlatDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeminjamanAlatDetails_Alats_AlatId",
                        column: x => x.AlatId,
                        principalTable: "Alats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeminjamanAlatDetails_PeminjamanAlats_PeminjamanAlatId",
                        column: x => x.PeminjamanAlatId,
                        principalTable: "PeminjamanAlats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeminjamanAlatDetails_AlatId",
                table: "PeminjamanAlatDetails",
                column: "AlatId");

            migrationBuilder.CreateIndex(
                name: "IX_PeminjamanAlatDetails_PeminjamanAlatId",
                table: "PeminjamanAlatDetails",
                column: "PeminjamanAlatId");

            migrationBuilder.CreateIndex(
                name: "IX_PeminjamanAlats_PeminjamId",
                table: "PeminjamanAlats",
                column: "PeminjamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeminjamanAlatDetails");

            migrationBuilder.DropTable(
                name: "Alats");

            migrationBuilder.DropTable(
                name: "PeminjamanAlats");

            migrationBuilder.DropTable(
                name: "Peminjams");
        }
    }
}
