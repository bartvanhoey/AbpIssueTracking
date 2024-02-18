using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracking.Migrations
{
    /// <inheritdoc />
    public partial class CreationTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppIssues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCommentTime",
                table: "AppIssues",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppIssues");

            migrationBuilder.DropColumn(
                name: "LastCommentTime",
                table: "AppIssues");
        }
    }
}
