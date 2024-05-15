using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {





            migrationBuilder.CreateIndex(
                name: "IX_LocationToRooms_LocationId",
                table: "LocationToRooms",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingEquipments_EquipmentID",
                table: "MeetingEquipments",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingEquipments_MeetingRequestID",
                table: "MeetingEquipments",
                column: "MeetingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomToEquipments_EquipmentID",
                table: "RoomToEquipments",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomToEquipments_RoomID",
                table: "RoomToEquipments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderID",
                table: "Users",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StafftitleID",
                table: "Users",
                column: "StafftitleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationToRooms");

            migrationBuilder.DropTable(
                name: "MeetingEquipments");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "RoomToEquipments");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MeetingRequest");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Stafftitles");
        }
    }
}
