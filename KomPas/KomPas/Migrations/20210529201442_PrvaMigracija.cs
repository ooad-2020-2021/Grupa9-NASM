using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace KomPas.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Datoteka = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    ForumID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BrojAktivnihKorisnika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.ForumID);
                });

            migrationBuilder.CreateTable(
                name: "Pas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Spol = table.Column<int>(nullable: false),
                    Rasa = table.Column<string>(nullable: false),
                    Tezina = table.Column<int>(nullable: false),
                    ZdravstveniProblem = table.Column<string>(nullable: false),
                    KastriranSterilisan = table.Column<bool>(nullable: false),
                    Slika = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podsjetnik",
                columns: table => new
                {
                    PodsjetnikID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tekst = table.Column<string>(nullable: false),
                    Termin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podsjetnik", x => x.PodsjetnikID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Pas_PasID",
                        column: x => x.PasID,
                        principalTable: "Pas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AutorKomentaraID = table.Column<int>(nullable: false),
                    VrijemeObjave = table.Column<DateTime>(nullable: false),
                    Tekst = table.Column<string>(nullable: false),
                    DokumentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_Komentar_Korisnik_AutorKomentaraID",
                        column: x => x.AutorKomentaraID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentar_Dokument_DokumentID",
                        column: x => x.DokumentID,
                        principalTable: "Dokument",
                        principalColumn: "DokumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tekst = table.Column<string>(nullable: false),
                    BrojKomentara = table.Column<int>(nullable: false),
                    BrojReakcija = table.Column<int>(nullable: false),
                    AutorPostaID = table.Column<int>(nullable: false),
                    DokumentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Post_Korisnik_AutorPostaID",
                        column: x => x.AutorPostaID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Dokument_DokumentID",
                        column: x => x.DokumentID,
                        principalTable: "Dokument",
                        principalColumn: "DokumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    ProfilID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    KorisnikID = table.Column<int>(nullable: false),
                    PasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.ProfilID);
                    table.ForeignKey(
                        name: "FK_Profil_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profil_Pas_PasID",
                        column: x => x.PasID,
                        principalTable: "Pas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjevZaUdomljavanje",
                columns: table => new
                {
                    ZahtjevZaUdomljavanjeID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Grad = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    ImaPsa = table.Column<bool>(nullable: false),
                    IzabraniPasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaUdomljavanje", x => x.ZahtjevZaUdomljavanjeID);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaUdomljavanje_Pas_IzabraniPasID",
                        column: x => x.IzabraniPasID,
                        principalTable: "Pas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaUdomljavanje_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_AutorKomentaraID",
                table: "Komentar",
                column: "AutorKomentaraID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_DokumentID",
                table: "Komentar",
                column: "DokumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_PasID",
                table: "Korisnik",
                column: "PasID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AutorPostaID",
                table: "Post",
                column: "AutorPostaID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_DokumentID",
                table: "Post",
                column: "DokumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Profil_KorisnikID",
                table: "Profil",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Profil_PasID",
                table: "Profil",
                column: "PasID");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevZaUdomljavanje_IzabraniPasID",
                table: "ZahtjevZaUdomljavanje",
                column: "IzabraniPasID");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevZaUdomljavanje_KorisnikID",
                table: "ZahtjevZaUdomljavanje",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Podsjetnik");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.DropTable(
                name: "ZahtjevZaUdomljavanje");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Pas");
        }
    }
}
