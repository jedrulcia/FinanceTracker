using FinanceTracker.EntityFramework;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.Repositories;
using Microsoft.EntityFrameworkCore;
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
		public ObservableCollection<string> Months { get; set; }
		public string SelectedMonth { get; set; }
		public List<OngoingExpensesVM> OngoingExpensesVMs { get; set; }
		public List<OtherExpensesVM> OtherExpensesVMs { get; set; }
		public List<SalaryVM> SalaryVMs { get; set; }
		private IOngoingExpensesRepository _ongoingExpensesRepository { get; set; } // SETUP DEPENDENCY INJECTION

		public MainVM()
		{
		}

		public async Task InitializeAsync()
		{
			GenerateMonthList();
			//OngoingExpensesVMs = await _ongoingExpensesRepository.GetOngoingExpensesVMAsync(SelectedMonth);
			//Debug.WriteLine("");
		}

		private void GenerateMonthList()
		{
			var months = new ObservableCollection<string>();

			var currentYear = DateTime.Now.Year;
			var currentMonth = DateTime.Now.Month;

			SelectedMonth = DateTime.Now.ToString("MM-yyyy");

			for (int year = currentYear + 1; year >= currentYear - 1; year--)
			{
				for (int month = 12; month >= 1; month--)
				{
					var newMonth = new DateTime(year, month, 1).ToString("MM-yyyy", CultureInfo.InvariantCulture);
					months.Add((newMonth));
				}
			}

			Months = months;
		}
	}
}
