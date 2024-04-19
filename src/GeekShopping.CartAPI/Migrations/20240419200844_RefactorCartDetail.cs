using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CartAPI.Migrations
{
    public partial class RefactorCartDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_detail_Categories_CategoryId",
                table: "cart_detail");

            migrationBuilder.DropIndex(
                name: "IX_cart_detail_CategoryId",
                table: "cart_detail");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "cart_detail");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "cart_detail",
                newName: "Count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "cart_detail",
                newName: "count");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "cart_detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_cart_detail_CategoryId",
                table: "cart_detail",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_detail_Categories_CategoryId",
                table: "cart_detail",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
