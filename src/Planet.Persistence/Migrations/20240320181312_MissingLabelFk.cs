using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planet.Persistence.Migrations
{
    public partial class MissingLabelFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CardLabels_BoardLabelId",
                table: "CardLabels",
                column: "BoardLabelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardLabels_BoardLabels_BoardLabelId",
                table: "CardLabels",
                column: "BoardLabelId",
                principalTable: "BoardLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardLabels_BoardLabels_BoardLabelId",
                table: "CardLabels");

            migrationBuilder.DropIndex(
                name: "IX_CardLabels_BoardLabelId",
                table: "CardLabels");
        }
    }
}
