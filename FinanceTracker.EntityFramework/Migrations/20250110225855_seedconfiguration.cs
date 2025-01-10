using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceTracker.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class seedconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Received",
                table: "Salary",
                newName: "Paid");

            migrationBuilder.AddColumn<int>(
                name: "OngoingExpenseTypesId",
                table: "OngoingExpenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OngoingExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngoingExpenseTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OngoingExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Jedzenie" },
                    { 2, "Paliwo" },
                    { 3, "Mieszkanie" },
                    { 4, "Rachunki" },
                    { 5, "Raty" },
                    { 6, " " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OngoingExpenseTypes");

            migrationBuilder.DropColumn(
                name: "OngoingExpenseTypesId",
                table: "OngoingExpenses");

            migrationBuilder.RenameColumn(
                name: "Paid",
                table: "Salary",
                newName: "Received");
        }
    }
}
