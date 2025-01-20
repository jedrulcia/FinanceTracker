using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace FinanceTracker.WPF.Contracts
{
	public interface IOngoingExpenseRepository : IGenericRepository<OngoingExpense>
	{
		Task<ObservableCollection<OngoingExpenseVM>> GetOngoingExpenseVMsAsync(string month);
		Task CreateOngoingExpenseAsync(CreateVM createVM);
	}
}
