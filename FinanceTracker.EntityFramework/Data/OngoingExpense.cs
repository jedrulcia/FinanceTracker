namespace FinanceTracker.EntityFramework.Data;

public class OngoingExpense
{
	public int? Id { get; set; }
	public int? ExpenseTypeId { get; set; }
	public string Name { get; set; }
	public int Value { get; set; }
	public DateTime Date { get; set; }
	public bool Paid { get; set; } = false;
}
