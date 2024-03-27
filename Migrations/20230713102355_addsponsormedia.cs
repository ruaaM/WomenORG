using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenORG.Migrations
{
    /// <inheritdoc />
    public partial class addsponsormedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantSpecialization_Specialization_SpecializationID",
                table: "ParticipantSpecialization");

            migrationBuilder.DropColumn(
                name: "ContractDocument",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Sponsor");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationID",
                table: "ParticipantSpecialization",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SponsorMedia",
                columns: table => new
                {
                    SponsorMediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypesID = table.Column<int>(type: "int", nullable: true),
                    SponsorID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorMedia", x => x.SponsorMediaID);
                    table.ForeignKey(
                        name: "FK_SponsorMedia_FileTypes_FileTypesID",
                        column: x => x.FileTypesID,
                        principalTable: "FileTypes",
                        principalColumn: "FileTypesID");
                    table.ForeignKey(
                        name: "FK_SponsorMedia_Sponsor_SponsorID",
                        column: x => x.SponsorID,
                        principalTable: "Sponsor",
                        principalColumn: "SponsorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SponsorMedia_FileTypesID",
                table: "SponsorMedia",
                column: "FileTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorMedia_SponsorID",
                table: "SponsorMedia",
                column: "SponsorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantSpecialization_Specialization_SpecializationID",
                table: "ParticipantSpecialization",
                column: "SpecializationID",
                principalTable: "Specialization",
                principalColumn: "SpecializationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantSpecialization_Specialization_SpecializationID",
                table: "ParticipantSpecialization");

            migrationBuilder.DropTable(
                name: "SponsorMedia");

            migrationBuilder.AddColumn<string>(
                name: "ContractDocument",
                table: "Sponsor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Sponsor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationID",
                table: "ParticipantSpecialization",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantSpecialization_Specialization_SpecializationID",
                table: "ParticipantSpecialization",
                column: "SpecializationID",
                principalTable: "Specialization",
                principalColumn: "SpecializationID");
        }
    }
}
