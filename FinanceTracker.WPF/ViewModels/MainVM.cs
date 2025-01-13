using FinanceTracker.EntityFramework;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{

	public class MainVM
	{
		private readonly IServiceProvider serviceProvider;

		public ObservableCollection<string> Months { get; set; }
		public string SelectedMonth { get; set; }
		public List<OngoingExpensesVM> OngoingExpensesVMs { get; set; }
		public ObservableCollection<OtherExpensesVM> OtherExpensesVMs { get; set; } = new ObservableCollection<OtherExpensesVM>();
		private IOngoingExpensesRepository ongoingExpensesRepository {  get; set; }
		private IOtherExpensesRepository otherExpensesRepository { get; set; }

		public MainVM(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
			this.ongoingExpensesRepository = serviceProvider.GetRequiredService<IOngoingExpensesRepository>();
			this.otherExpensesRepository = serviceProvider.GetRequiredService<IOtherExpensesRepository>();
		}

		public async Task InitializeAsync()
		{
			GenerateMonthList();
			this.OngoingExpensesVMs = await ongoingExpensesRepository.GetOngoingExpensesVMAsync(SelectedMonth);
			this.OtherExpensesVMs = await otherExpensesRepository.GetOtherExpensesVMAsync(SelectedMonth);
		}

		private void GenerateMonthList()
		{
			var months = new ObservableCollection<string>();

			var currentYear = DateTime.Now.Year;
			var currentMonth = DateTime.Now.Month;

			this.SelectedMonth = DateTime.Now.ToString("MM-yyyy");

			for (int year = currentYear + 1; year >= currentYear - 1; year--)
			{
				for (int month = 12; month >= 1; month--)
				{
					var newMonth = new DateTime(year, month, 1).ToString("MM-yyyy", CultureInfo.InvariantCulture);
					months.Add((newMonth));
				}
			}

			this.Months = months;
		}
	}
}
