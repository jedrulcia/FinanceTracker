using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FinanceTracker.WPF.Repositories
{
	public class OtherExpensesRepository : GenericRepository<OtherExpenses>, IOtherExpensesRepository
	{
		private readonly AppDbContext context;

		public OtherExpensesRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<ObservableCollection<OtherExpensesVM>> GetOtherExpensesVMAsync(string month)
		{
			List<OtherExpenses> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<OtherExpensesVM> listVM = new ObservableCollection<OtherExpensesVM>();

			foreach (var item in list)
			{
				listVM.Add(new OtherExpensesVM(item));
			}
			return listVM;
		}

	}
}
