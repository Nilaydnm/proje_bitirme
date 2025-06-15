using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projebitirme.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Tip = table.Column<string>(type: "TEXT", nullable: false),
                    Yil = table.Column<int>(type: "INTEGER", nullable: false),
                    MotorHacmi = table.Column<double>(type: "REAL", nullable: false),
                    BeygirGucu = table.Column<int>(type: "INTEGER", nullable: false),
                    AgirlikKg = table.Column<int>(type: "INTEGER", nullable: false),
                    Sanziman = table.Column<string>(type: "TEXT", nullable: false),
                    Mpg = table.Column<double>(type: "REAL", nullable: false),
                    Litre100Km = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracVerileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MotorHacmi = table.Column<double>(type: "REAL", nullable: false),
                    Yil = table.Column<int>(type: "INTEGER", nullable: false),
                    Silindir = table.Column<int>(type: "INTEGER", nullable: false),
                    Sanziman = table.Column<string>(type: "TEXT", nullable: false),
                    YakitTuru = table.Column<string>(type: "TEXT", nullable: false),
                    AracSinifi = table.Column<string>(type: "TEXT", nullable: false),
                    Emisyon = table.Column<double>(type: "REAL", nullable: false),
                    Litre100Km = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracVerileri", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "AracVerileri");
        }
    }
}
