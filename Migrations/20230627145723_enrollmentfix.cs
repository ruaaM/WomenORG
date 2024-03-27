using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenORG.Migrations
{
    /// <inheritdoc />
    public partial class enrollmentfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Participant_ID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Enrollments");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ParticipantID",
                table: "Enrollments",
                column: "ParticipantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Participant_ParticipantID",
                table: "Enrollments",
                column: "ParticipantID",
                principalTable: "Participant",
                principalColumn: "ParticipantID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Participant_ParticipantID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ParticipantID",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ID",
                table: "Enrollments",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Participant_ID",
                table: "Enrollments",
                column: "ID",
                principalTable: "Participant",
                principalColumn: "ParticipantID");
        }
    }
}
