using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShooping.CouponAPI.Migrations
{
    public partial class AdicaoCoupons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "id", "CouponCode", "DiscountAmount" },
                values: new object[] { 1L, "Batata_2024", 10.0 });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "id", "CouponCode", "DiscountAmount" },
                values: new object[] { 2L, "Macaxeira_2024", 15.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
