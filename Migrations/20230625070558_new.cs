using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenORG.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Street_StreetID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "isOnline",
                table: "LearningProgramDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StreetID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Street_StreetID",
                table: "AspNetUsers",
                column: "StreetID",
                principalTable: "Street",
                principalColumn: "StreetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Street_StreetID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isOnline",
                table: "LearningProgramDetails");

            migrationBuilder.AlterColumn<int>(
                name: "StreetID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Street_StreetID",
                table: "AspNetUsers",
                column: "StreetID",
                principalTable: "Street",
                principalColumn: "StreetID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
