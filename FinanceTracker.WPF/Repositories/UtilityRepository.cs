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
		private IOngoingExpenseRepository ongoingExpenseRepository;
		private IOtherExpenseRepository otherExpenseRepository;
		private IExpenseTypeRepository expenseTypeRepository;

		public UtilityRepository(IServiceProvider serviceProvider)
		{
			this.ongoingExpenseRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
			this.otherExpenseRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
			this.expenseTypeRepository = serviceProvider.GetRequiredService<IExpenseTypeRepository>();
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

		public async Task<ObservableCollection<OverduePaymentVM>> GetOverduePaymentVMsAsync(string month)
		{
			var targetDate = DateTime.ParseExact(month, "MM-yyyy", null);
			ObservableCollection<OverduePaymentVM> listVM = new ObservableCollection<OverduePaymentVM>();

			List<OngoingExpense> ongoingList = (await ongoingExpenseRepository.GetAllAsync()).Where(x => x.Date < targetDate).ToList();
			foreach (var item in ongoingList)
			{
				var type = await expenseTypeRepository.GetAsync(item.ExpenseTypeId);
				listVM.Add(new OverduePaymentVM(item.Id, item.Name, item.Value, item.Date, type));
			}

			List<OtherExpense> list = (await otherExpenseRepository.GetAllAsync()).Where(x => x.Date < targetDate && x.Paid == false).ToList();
			foreach (var item in list)
			{
				var type = await expenseTypeRepository.GetAsync(item.ExpenseTypeId);
				listVM.Add(new OverduePaymentVM(item.Id, item.Name, item.Value, item.Date, type));
			}

			return listVM;
		}
	}
}
