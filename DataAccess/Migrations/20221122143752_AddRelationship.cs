using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DestinationDetails_DestinationId",
                table: "DestinationDetails",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationDetails_GuideId",
                table: "DestinationDetails",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationDetails_Destinations_DestinationId",
                table: "DestinationDetails",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationDetails_Guides_GuideId",
                table: "DestinationDetails",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationDetails_Destinations_DestinationId",
                table: "DestinationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationDetails_Guides_GuideId",
                table: "DestinationDetails");

            migrationBuilder.DropIndex(
                name: "IX_DestinationDetails_DestinationId",
                table: "DestinationDetails");

            migrationBuilder.DropIndex(
                name: "IX_DestinationDetails_GuideId",
                table: "DestinationDetails");
        }
    }
}
