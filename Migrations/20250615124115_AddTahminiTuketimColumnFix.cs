using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projebitirme.Migrations
{
    /// <inheritdoc />
    public partial class AddTahminiTuketimColumnFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TahminiTuketim",
                table: "AracVerileri",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TahminiTuketim",
                table: "AracVerileri");
        }
    }
}
