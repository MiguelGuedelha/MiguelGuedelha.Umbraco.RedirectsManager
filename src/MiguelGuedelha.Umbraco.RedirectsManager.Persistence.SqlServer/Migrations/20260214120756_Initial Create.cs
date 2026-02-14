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
                name: "redirectsManager",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siteId = table.Column<int>(type: "int", nullable: false, defaultValue: -1),
                    siteKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    originUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    destinationType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    destinationId = table.Column<int>(type: "int", nullable: true),
                    destinationKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    destinationUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    query = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    culture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isRegex = table.Column<bool>(type: "bit", nullable: false),
                    isPermanent = table.Column<bool>(type: "bit", nullable: false),
                    forwardQuery = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redirectsManager", x => x.id);
                    table.CheckConstraint("CK_GlobalOrScopedSiteSet", "(\r\n    siteId = -1 \r\n    AND\r\n    siteKey = '00000000-0000-0000-0000-000000000000'\r\n)\r\nOR\r\n(\r\n    siteId > -1 \r\n    AND \r\n    siteKey <> '00000000-0000-0000-0000-000000000000'\r\n)");
                    table.CheckConstraint("CK_OneDestinationSet", "(\r\n    destinationId IS NOT NULL \r\n    AND \r\n    (\r\n        destinationUrl IS NULL \r\n        OR \r\n        destinationUrl = ''\r\n    )\r\n) \r\nOR \r\n(\r\n    destinationId IS NULL \r\n    AND \r\n    (\r\n        destinationUrl IS NOT NULL \r\n        AND \r\n        destinationUrl <> ''\r\n    )\r\n)");
                });

            migrationBuilder.CreateIndex(
                name: "IX_redirectsManager_destinationId",
                table: "redirectsManager",
                column: "destinationId");

            migrationBuilder.CreateIndex(
                name: "IX_redirectsManager_siteId_originUrl",
                table: "redirectsManager",
                columns: new[] { "siteId", "originUrl" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "redirectsManager");
        }
    }
}
