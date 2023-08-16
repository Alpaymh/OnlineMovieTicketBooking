using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMovieTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class _6_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Uyeler");

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Uyeler",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_RolID",
                table: "Uyeler",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uyeler_Roller_RolID",
                table: "Uyeler",
                column: "RolID",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uyeler_Roller_RolID",
                table: "Uyeler");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropIndex(
                name: "IX_Uyeler_RolID",
                table: "Uyeler");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Uyeler");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Uyeler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
