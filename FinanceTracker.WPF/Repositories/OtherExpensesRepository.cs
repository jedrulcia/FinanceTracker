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
		private readonly FinanceTrackerDbContext context;

		public OtherExpensesRepository(FinanceTrackerDbContext context) : base(context)
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


		public (ObservableCollection<string> months, string selectedMonth) GenerateMonthList()
		{
			var months = new ObservableCollection<string>();

			var currentYear = DateTime.Now.Year;
			var currentMonth = DateTime.Now.Month;

			var selectedMonth = DateTime.Now.ToString("MM-yyyy");

			for (int year = currentYear + 1; year >= currentYear - 1; year--)
			{
				for (int month = 12; month >= 1; month--)
				{
					var newMonth = new DateTime(year, month, 1).ToString("MM-yyyy", CultureInfo.InvariantCulture);
					months.Add((newMonth));
				}
			}

			return (months, selectedMonth);
		}
	}
}
