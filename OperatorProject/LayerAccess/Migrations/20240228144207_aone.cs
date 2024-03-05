using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayerAccess.Migrations
{
    /// <inheritdoc />
    public partial class aone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinsiyet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HatTuru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HatTuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdemeDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeDetay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarife",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HatTuruId = table.Column<int>(type: "int", nullable: false),
                    TarifeAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifeUcreti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarife", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarife_HatTuru_HatTuruId",
                        column: x => x.HatTuruId,
                        principalTable: "HatTuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KimlikBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CinsiyetId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KimlikBilgileri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KimlikId = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteri_KimlikBilgileri_KimlikId",
                        column: x => x.KimlikId,
                        principalTable: "KimlikBilgileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusteriPaketTutar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    TarifeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriPaketTutar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriPaketTutar_Musteri_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusteriPaketTutar_Tarife_TarifeId",
                        column: x => x.TarifeId,
                        principalTable: "Tarife",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdemeGecmisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    Detay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tutar = table.Column<int>(type: "int", nullable: false),
                    OdemeTurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeGecmisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdemeGecmisi_Musteri_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdemeGecmisi_OdemeDetay_OdemeTurId",
                        column: x => x.OdemeTurId,
                        principalTable: "OdemeDetay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TalepKaydi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StatuId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalepKaydi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalepKaydi_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TalepKaydi_Musteri_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalepKaydi_Statu_StatuId",
                        column: x => x.StatuId,
                        principalTable: "Statu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KimlikBilgileri_MusteriId",
                table: "KimlikBilgileri",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_KimlikId",
                table: "Musteri",
                column: "KimlikId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriPaketTutar_MusteriId",
                table: "MusteriPaketTutar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriPaketTutar_TarifeId",
                table: "MusteriPaketTutar",
                column: "TarifeId");

            migrationBuilder.CreateIndex(
                name: "IX_OdemeGecmisi_MusteriId",
                table: "OdemeGecmisi",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_OdemeGecmisi_OdemeTurId",
                table: "OdemeGecmisi",
                column: "OdemeTurId");

            migrationBuilder.CreateIndex(
                name: "IX_TalepKaydi_KullaniciId",
                table: "TalepKaydi",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_TalepKaydi_MusteriId",
                table: "TalepKaydi",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_TalepKaydi_StatuId",
                table: "TalepKaydi",
                column: "StatuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarife_HatTuruId",
                table: "Tarife",
                column: "HatTuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_KimlikBilgileri_Musteri_MusteriId",
                table: "KimlikBilgileri",
                column: "MusteriId",
                principalTable: "Musteri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KimlikBilgileri_Musteri_MusteriId",
                table: "KimlikBilgileri");

            migrationBuilder.DropTable(
                name: "Cinsiyet");

            migrationBuilder.DropTable(
                name: "MusteriPaketTutar");

            migrationBuilder.DropTable(
                name: "OdemeGecmisi");

            migrationBuilder.DropTable(
                name: "TalepKaydi");

            migrationBuilder.DropTable(
                name: "Tarife");

            migrationBuilder.DropTable(
                name: "OdemeDetay");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Statu");

            migrationBuilder.DropTable(
                name: "HatTuru");

            migrationBuilder.DropTable(
                name: "Musteri");

            migrationBuilder.DropTable(
                name: "KimlikBilgileri");
        }
    }
}
