namespace FinanceTracker.EntityFramework.Data;

public class OtherExpenses
{
	public int? Id { get; set; }
	public string Name { get; set; }
	public int Value { get; set; }
	public DateTime Date { get; set; }
	public bool Paid { get; set; } = false;
}
