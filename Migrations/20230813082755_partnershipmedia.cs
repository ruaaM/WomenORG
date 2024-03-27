using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenORG.Migrations
{
    /// <inheritdoc />
    public partial class partnershipmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractDocument",
                table: "Partnership");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Partnership");

            migrationBuilder.CreateTable(
                name: "PartnershipMedia",
                columns: table => new
                {
                    PartnershipMediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypesID = table.Column<int>(type: "int", nullable: true),
                    PartnershipID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnershipMedia", x => x.PartnershipMediaID);
                    table.ForeignKey(
                        name: "FK_PartnershipMedia_FileTypes_FileTypesID",
                        column: x => x.FileTypesID,
                        principalTable: "FileTypes",
                        principalColumn: "FileTypesID");
                    table.ForeignKey(
                        name: "FK_PartnershipMedia_Partnership_PartnershipID",
                        column: x => x.PartnershipID,
                        principalTable: "Partnership",
                        principalColumn: "PartnershipID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipMedia_FileTypesID",
                table: "PartnershipMedia",
                column: "FileTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipMedia_PartnershipID",
                table: "PartnershipMedia",
                column: "PartnershipID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnershipMedia");

            migrationBuilder.AddColumn<string>(
                name: "ContractDocument",
                table: "Partnership",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Partnership",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
