using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Nomenclature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OngoingExpenseTypeId",
                table: "OtherExpenses",
                newName: "ExpenseTypeId");

            migrationBuilder.RenameColumn(
                name: "OngoingExpenseTypeId",
                table: "OngoingExpenses",
                newName: "ExpenseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseTypeId",
                table: "OtherExpenses",
                newName: "OngoingExpenseTypeId");

            migrationBuilder.RenameColumn(
                name: "ExpenseTypeId",
                table: "OngoingExpenses",
                newName: "OngoingExpenseTypeId");
        }
    }
}
