using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.Repositories
{
	public class UtilityRepository : IUtilityRepository
	{
		private IOngoingExpenseRepository ongoingExpensesRepository;
		private IOtherExpenseRepository otherExpensesRepository;

		public UtilityRepository(IServiceProvider serviceProvider)
		{
			this.ongoingExpensesRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
			this.otherExpensesRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
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

/*		public async Task<ObservableCollection<OverduePaymentVM>> GenerateOverduePaymentListAsync(string month)
		{
			var targetDate = DateTime.ParseExact(month, "MM-yyyy", null);
			List<OngoingExpenses> ongoingList = (await ongoingExpensesRepository.GetAllAsync()).Where(x => x.Date < targetDate).ToList();
			ObservableCollection<OverduePaymentVM> listVM = new ObservableCollection<OverduePaymentVM>();

			foreach (var item in ongoingList)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.OngoingExpenseTypesId);
				listVM.Add(new OngoingExpensesVM(item, type));
			}

			List<OtherExpenses> list = (await GetAllAsync()).Where(x => x.Date < targetDate && x.Paid == false).ToList();

			foreach (var item in list)
			{
				listVM.Add(new OtherExpensesVM(item));
			}
			return listVM;
		}*/
	}
}
