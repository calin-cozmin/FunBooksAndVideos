using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunBooksAndVideos.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PaymentType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PaymentType");
        }
    }
}
