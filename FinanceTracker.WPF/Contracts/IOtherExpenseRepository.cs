using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace FinanceTracker.WPF.Contracts
{
	public interface IOtherExpenseRepository : IGenericRepository<OtherExpense>
	{
		Task<ObservableCollection<OtherExpenseVM>> GetOtherExpensesVMAsync(string month);
		Task<ObservableCollection<OtherExpenseVM>> GetOverdueOtherExpensesVMAsync(string month);
	}
}
