namespace FinanceTracker.Domain.Data;

public class Salary
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Value { get; set; }
	public DateTime Date { get; set; }
	public bool Received { get; set; } = false;
}
