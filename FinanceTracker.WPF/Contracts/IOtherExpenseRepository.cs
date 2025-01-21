using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace FinanceTracker.WPF.Contracts
{
	public interface IOtherExpenseRepository : IGenericRepository<OtherExpense>
	{
		Task<ObservableCollection<OtherExpenseVM>> GetOtherExpenseVMsAsync(string month);
		Task CreateOtherExpenseAsync(CreateVM createVM);
		Task<EditVM> GetOtherExpenseEditVMAsync(int id);
		Task EditOtherExpenseAsync(EditVM editVM);
	}
}
