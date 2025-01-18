using FinanceTracker.EntityFramework;
using FinanceTracker.WPF.Contracts;
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
		private readonly AppDbContext context;

		public UtilityRepository(AppDbContext context)
		{
			this.context = context;
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
