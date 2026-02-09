using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.SqlServer.Migrations
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    originUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destinationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    destinationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRegex = table.Column<bool>(type: "bit", nullable: false),
                    isPermanent = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
