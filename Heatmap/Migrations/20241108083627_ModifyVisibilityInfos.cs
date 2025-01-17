using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heatmap.Migrations
{
    /// <inheritdoc />
    public partial class ModifyVisibilityInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_visible_time",
                table: "VisibilityInfos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Last_visible_time",
                table: "VisibilityInfos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
