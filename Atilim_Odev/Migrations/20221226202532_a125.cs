using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atilim_Odev.Migrations
{
    public partial class a125 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    Kredi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mufredatlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MufredatAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mufredatlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol_Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kimlik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC_No = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IletisimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kimlik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kimlik_Iletisim_IletisimId",
                        column: x => x.IletisimId,
                        principalTable: "Iletisim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DerslerMufredat",
                columns: table => new
                {
                    DerslerId = table.Column<int>(type: "int", nullable: false),
                    MufredatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerslerMufredat", x => new { x.DerslerId, x.MufredatId });
                    table.ForeignKey(
                        name: "FK_DerslerMufredat_Dersler_DerslerId",
                        column: x => x.DerslerId,
                        principalTable: "Dersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DerslerMufredat_Mufredatlar_MufredatId",
                        column: x => x.MufredatId,
                        principalTable: "Mufredatlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kullanici_Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tur = table.Column<int>(type: "int", nullable: false),
                    kimlikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Kimlik_kimlikId",
                        column: x => x.kimlikId,
                        principalTable: "Kimlik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ogr_No = table.Column<int>(type: "int", nullable: false),
                    KimlikId = table.Column<int>(type: "int", nullable: false),
                    MufredatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrenci_Kimlik_KimlikId",
                        column: x => x.KimlikId,
                        principalTable: "Kimlik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogrenci_Mufredatlar_MufredatId",
                        column: x => x.MufredatId,
                        principalTable: "Mufredatlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullanicilarRol",
                columns: table => new
                {
                    KullanicilarId = table.Column<int>(type: "int", nullable: false),
                    RollerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullanicilarRol", x => new { x.KullanicilarId, x.RollerId });
                    table.ForeignKey(
                        name: "FK_KullanicilarRol_Kullanicilar_KullanicilarId",
                        column: x => x.KullanicilarId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullanicilarRol_Roller_RollerId",
                        column: x => x.RollerId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ders_Kayit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders_Kayit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ders_Kayit_Dersler_DersId",
                        column: x => x.DersId,
                        principalTable: "Dersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ders_Kayit_Ogrenci_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_Kayit_DersId",
                table: "Ders_Kayit",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Ders_Kayit_OgrenciId",
                table: "Ders_Kayit",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_DerslerMufredat_MufredatId",
                table: "DerslerMufredat",
                column: "MufredatId");

            migrationBuilder.CreateIndex(
                name: "IX_Kimlik_IletisimId",
                table: "Kimlik",
                column: "IletisimId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_kimlikId",
                table: "Kullanicilar",
                column: "kimlikId");

            migrationBuilder.CreateIndex(
                name: "IX_KullanicilarRol_RollerId",
                table: "KullanicilarRol",
                column: "RollerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenci_KimlikId",
                table: "Ogrenci",
                column: "KimlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenci_MufredatId",
                table: "Ogrenci",
                column: "MufredatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ders_Kayit");

            migrationBuilder.DropTable(
                name: "DerslerMufredat");

            migrationBuilder.DropTable(
                name: "KullanicilarRol");

            migrationBuilder.DropTable(
                name: "Ogrenci");

            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Mufredatlar");

            migrationBuilder.DropTable(
                name: "Kimlik");

            migrationBuilder.DropTable(
                name: "Iletisim");
        }
    }
}
