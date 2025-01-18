using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FinanceTracker.WPF.Repositories
{
	public class OtherExpenseRepository : GenericRepository<OtherExpense>, IOtherExpenseRepository
	{
		private readonly AppDbContext context;

		public OtherExpenseRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<ObservableCollection<OtherExpenseVM>> GetOtherExpensesVMAsync(string month)
		{
			List<OtherExpense> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<OtherExpenseVM> listVM = new ObservableCollection<OtherExpenseVM>();

			foreach (var item in list)
			{
				listVM.Add(new OtherExpenseVM(item));
			}
			return listVM;
		}

		public async Task<ObservableCollection<OtherExpenseVM>> GetOverdueOtherExpensesVMAsync(string month)
		{
			var targetDate = DateTime.ParseExact(month, "MM-yyyy", null);
			List<OtherExpense> list = (await GetAllAsync()).Where(x => x.Date < targetDate && x.Paid == false).ToList();
			ObservableCollection<OtherExpenseVM> listVM = new ObservableCollection<OtherExpenseVM>();

			foreach (var item in list)
			{
				listVM.Add(new OtherExpenseVM(item));
			}
			return listVM;
		}

	}
}
