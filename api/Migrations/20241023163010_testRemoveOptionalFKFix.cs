using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class testRemoveOptionalFKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_MeetingRooms_MeetingRoomId",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_MeetingRooms_MeetingRoomId",
                table: "Activities",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_MeetingRooms_MeetingRoomId",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_MeetingRooms_MeetingRoomId",
                table: "Activities",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
