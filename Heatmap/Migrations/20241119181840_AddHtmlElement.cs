using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heatmap.Migrations
{
    /// <inheritdoc />
    public partial class AddHtmlElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "SiteVersions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteVersions",
                table: "SiteVersions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteVersions",
                table: "SiteVersions");

            migrationBuilder.RenameTable(
                name: "SiteVersions",
                newName: "Site");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "Id");
        }
    }
}
