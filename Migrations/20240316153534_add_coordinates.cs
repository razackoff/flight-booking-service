using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flight_booking_service.Migrations
{
    /// <inheritdoc />
    public partial class add_coordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Coordinates_CoordinatesId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CoordinatesId",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "CoordinatesId",
                table: "Destinations",
                newName: "CoordinatesID");

            migrationBuilder.AlterColumn<string>(
                name: "CoordinatesID",
                table: "Destinations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoordinatesID",
                table: "Destinations",
                newName: "CoordinatesId");

            migrationBuilder.AlterColumn<string>(
                name: "CoordinatesId",
                table: "Destinations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CoordinatesId",
                table: "Destinations",
                column: "CoordinatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Coordinates_CoordinatesId",
                table: "Destinations",
                column: "CoordinatesId",
                principalTable: "Coordinates",
                principalColumn: "Id");
        }
    }
}
