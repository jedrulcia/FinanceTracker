using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace FinanceTracker.WPF.Contracts
{
	public interface IOtherExpensesRepository : IGenericRepository<OtherExpenses>
	{
		Task<ObservableCollection<OtherExpensesVM>> GetOtherExpensesVMAsync(string month);
	}
}
