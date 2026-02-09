using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RedirectsManager",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    siteId = table.Column<Guid>(type: "TEXT", nullable: true),
                    originUrl = table.Column<string>(type: "TEXT", nullable: false),
                    destinationType = table.Column<string>(type: "TEXT", nullable: false),
                    destinationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    destinationUrl = table.Column<string>(type: "TEXT", nullable: true),
                    culture = table.Column<string>(type: "TEXT", nullable: true),
                    isRegex = table.Column<bool>(type: "INTEGER", nullable: false),
                    isPermanent = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectsManager", x => x.id);
                    table.CheckConstraint("CK_OneDestinationSet", "(destinationId IS NOT NULL AND (destinationUrl IS NULL OR destinationUrl = '')) \nOR \n(destinationId IS NULL AND (destinationUrl IS NOT NULL AND destinationUrl <> ''))");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedirectsManager");
        }
    }
}
