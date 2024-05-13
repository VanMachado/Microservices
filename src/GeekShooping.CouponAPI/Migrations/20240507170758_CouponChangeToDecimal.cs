using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShooping.CouponAPI.Migrations
{
    public partial class CouponChangeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "id",
                keyValue: 1L,
                column: "DiscountAmount",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "id",
                keyValue: 2L,
                column: "DiscountAmount",
                value: 15m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "id",
                keyValue: 1L,
                column: "DiscountAmount",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "id",
                keyValue: 2L,
                column: "DiscountAmount",
                value: 15.0);
        }
    }
}
