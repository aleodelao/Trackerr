using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackerr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamedArtistMonitoredColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Monitored",
                table: "Artists",
                newName: "IsMonitored");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMonitored",
                table: "Artists",
                newName: "Monitored");
        }
    }
}
