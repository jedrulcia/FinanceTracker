using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;

namespace FinanceTracker.WPF.Contracts
{
	public interface IOngoingExpensesRepository : IGenericRepository<OngoingExpenses>
	{
		Task<List<OngoingExpensesVM>> GetOngoingExpensesVMAsync(string month);
	}
}
