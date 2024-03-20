using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planet.Persistence.Migrations
{
    public partial class ChangeDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardComments_Users_UserId",
                table: "CardComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CardLabels_BoardLabels_BoardLabelId",
                table: "CardLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_OwnerId",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardComments_Users_UserId",
                table: "CardComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardLabels_BoardLabels_BoardLabelId",
                table: "CardLabels",
                column: "BoardLabelId",
                principalTable: "BoardLabels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_OwnerId",
                table: "Cards",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardComments_Users_UserId",
                table: "CardComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CardLabels_BoardLabels_BoardLabelId",
                table: "CardLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_OwnerId",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardComments_Users_UserId",
                table: "CardComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardLabels_BoardLabels_BoardLabelId",
                table: "CardLabels",
                column: "BoardLabelId",
                principalTable: "BoardLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_OwnerId",
                table: "Cards",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
