using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenORG.Migrations
{
    /// <inheritdoc />
    public partial class addParticipantMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserImage",
                newName: "FileName");

            migrationBuilder.CreateTable(
                name: "ParticipantMedia",
                columns: table => new
                {
                    ParticipantMediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypesID = table.Column<int>(type: "int", nullable: true),
                    ParticipantID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantMedia", x => x.ParticipantMediaID);
                    table.ForeignKey(
                        name: "FK_ParticipantMedia_FileTypes_FileTypesID",
                        column: x => x.FileTypesID,
                        principalTable: "FileTypes",
                        principalColumn: "FileTypesID");
                    table.ForeignKey(
                        name: "FK_ParticipantMedia_Participant_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Participant",
                        principalColumn: "ParticipantID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantMedia_FileTypesID",
                table: "ParticipantMedia",
                column: "FileTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantMedia_ParticipantID",
                table: "ParticipantMedia",
                column: "ParticipantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantMedia");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "UserImage",
                newName: "Title");
        }
    }
}
