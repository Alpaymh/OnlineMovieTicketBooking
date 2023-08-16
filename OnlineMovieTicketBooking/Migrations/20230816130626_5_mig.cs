using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMovieTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class _5_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilResimDosyası",
                table: "Uyeler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                defaultValue: "no-profile.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilResimDosyası",
                table: "Uyeler");
        }
    }
}
