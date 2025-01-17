using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heatmap.Migrations
{
    /// <inheritdoc />
    public partial class AddHtmlElementType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Visibility_infos",
                table: "Visibility_infos");

            migrationBuilder.RenameTable(
                name: "Visibility_infos",
                newName: "VisibilityInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisibilityInfos",
                table: "VisibilityInfos",
                column: "Visibility_info_id");

            migrationBuilder.CreateTable(
                name: "HtmlElementTypes",
                columns: table => new
                {
                    Type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlElementTypes", x => x.Type_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlElementTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisibilityInfos",
                table: "VisibilityInfos");

            migrationBuilder.RenameTable(
                name: "VisibilityInfos",
                newName: "Visibility_infos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visibility_infos",
                table: "Visibility_infos",
                column: "Visibility_info_id");
        }
    }
}
