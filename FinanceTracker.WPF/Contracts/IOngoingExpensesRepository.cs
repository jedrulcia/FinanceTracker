using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace FinanceTracker.WPF.Contracts
{
	public interface IOngoingExpensesRepository : IGenericRepository<OngoingExpenses>
	{
		Task<ObservableCollection<OngoingExpensesVM>> GetOngoingExpensesVMAsync(string month);
	}
}
