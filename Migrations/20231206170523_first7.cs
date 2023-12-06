using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_System.Migrations
{
    /// <inheritdoc />
    public partial class first7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Events_EventId1",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_EventId1",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventId1",
                table: "tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_EventId1",
                table: "tickets",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_Events_EventId1",
                table: "tickets",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
