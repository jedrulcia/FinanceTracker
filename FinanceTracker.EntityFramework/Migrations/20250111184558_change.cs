using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OngoingExpenseTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Inne");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OngoingExpenseTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: " ");
        }
    }
}
