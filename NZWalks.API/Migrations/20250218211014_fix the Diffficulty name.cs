using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class fixtheDiffficultyname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DiffficultyrtyId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "DiffficultyrtyId",
                table: "Walks",
                newName: "DiffficultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DiffficultyrtyId",
                table: "Walks",
                newName: "IX_Walks_DiffficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DiffficultyId",
                table: "Walks",
                column: "DiffficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DiffficultyId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "DiffficultyId",
                table: "Walks",
                newName: "DiffficultyrtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DiffficultyId",
                table: "Walks",
                newName: "IX_Walks_DiffficultyrtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DiffficultyrtyId",
                table: "Walks",
                column: "DiffficultyrtyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
