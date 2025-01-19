using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace FinanceTracker.WPF.Repositories
{
	public class UtilityRepository : IUtilityRepository
	{
		private IOngoingExpenseRepository ongoingExpenseRepository;
		private IOtherExpenseRepository otherExpenseRepository;
		private IExpenseTypeRepository expenseTypeRepository;
		private ISalaryRepository salaryRepository;

		public UtilityRepository(IServiceProvider serviceProvider)
		{
			this.ongoingExpenseRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
			this.otherExpenseRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
			this.expenseTypeRepository = serviceProvider.GetRequiredService<IExpenseTypeRepository>();
			this.salaryRepository = serviceProvider.GetRequiredService<ISalaryRepository>();
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
				listVM.Add(new OverduePaymentVM(item.Id, item.Name, item.Value, item.Date, type, true));
			}

			List<OtherExpense> list = (await otherExpenseRepository.GetAllAsync()).Where(x => x.Date < targetDate && x.Paid == false).ToList();
			foreach (var item in list)
			{
				var type = await expenseTypeRepository.GetAsync(item.ExpenseTypeId);
				listVM.Add(new OverduePaymentVM(item.Id, item.Name, item.Value, item.Date, type, false));
			}

			return listVM;
		}

		public async Task<SummaryVM> GetMonthlySummaryVMAsync(string month)
		{
			int charges = (await ongoingExpenseRepository.GetAllAsync())
				.Where(x => x.Date.ToString("MM-yyyy") == month)
				.Sum(x => x.Value);

			charges += (await otherExpenseRepository.GetAllAsync())
				.Where(x => x.Date.ToString("MM-yyyy") == month)
				.Sum(x => x.Value);

			int credits = (await salaryRepository.GetAllAsync())
				.Where(x => x.Date.ToString("MM-yyyy") == month)
				.Sum(x => x.Value);

			int balance = credits - charges;

			return new SummaryVM(balance, credits, charges);
		}

		public async Task<SummaryVM> GetYearlySummaryVMAsync(string month)
		{
			string year = month.Substring(3);

			int charges = (await ongoingExpenseRepository.GetAllAsync())
				.Where(x => x.Date.ToString("yyyy") == year)
				.Sum(x => x.Value);

			charges += (await otherExpenseRepository.GetAllAsync())
				.Where(x => x.Date.ToString("yyyy") == year)
				.Sum(x => x.Value);

			int credits = (await salaryRepository.GetAllAsync())
				.Where(x => x.Date.ToString("yyyy") == year)
				.Sum(x => x.Value);

			int balance = credits - charges;

			return new SummaryVM(balance, credits, charges);
		}

		public async Task<(ChartValues<int> charges, ChartValues<int> credits)> GetColumnChartVMsAsync(string month)
		{
			string year = month.Substring(3);

			ChartValues<int> charges = new ChartValues<int>();
			ChartValues<int> credits = new ChartValues<int>();


			for (int i = 1; i <= 12; i++)
			{
				string currentMonth = $"{i:D2}-{year}";

				int credit = (await salaryRepository.GetAllAsync())
					.Where(x => x.Date.ToString("MM-yyyy") == currentMonth)
					.Sum(x => x.Value);

				int charge = (await ongoingExpenseRepository.GetAllAsync())
					.Where(x => x.Date.ToString("MM-yyyy") == currentMonth)
					.Sum(x => x.Value);

				charge += (await otherExpenseRepository.GetAllAsync())
					.Where(x => x.Date.ToString("MM-yyyy") == currentMonth)
					.Sum(x => x.Value);

				credits.Add(credit);
				charges.Add(charge);
			}

			return (credits, charges);
		}

		public async Task<PieChartVM> GetPieChartVMAsync(string month)
		{
			List<int> values = new List<int>([0, 0, 0, 0, 0, 0]);

			var ongoing = await ongoingExpenseRepository.GetOngoingExpenseVMsAsync(month);
			var other = await otherExpenseRepository.GetOtherExpenseVMsAsync(month);

			foreach (var item in ongoing)
			{
				values[item.Type.Id - 1] += item.Value;
			}

			foreach (var item in other)
			{
				values[item.Type.Id - 1] += item.Value;
			}

			List<ChartValues<ObservableValue>> result = new List<ChartValues<ObservableValue>>();

			foreach (var item in values)
			{
				var newObject = new ChartValues<ObservableValue> { new ObservableValue(item) };
				result.Add(newObject);
			}


			return new PieChartVM(result);
		}
	}
}
