using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMovieTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class _4_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Uyeler");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Uyeler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Uyeler");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Uyeler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
