using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMovieTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class _3_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Kilit",
                table: "Uyeler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilit",
                table: "Uyeler");
        }
    }
}
