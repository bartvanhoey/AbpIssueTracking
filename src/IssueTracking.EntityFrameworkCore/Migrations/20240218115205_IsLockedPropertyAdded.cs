using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracking.Migrations
{
    /// <inheritdoc />
    public partial class IsLockedPropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppIssues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppIssues");
        }
    }
}
