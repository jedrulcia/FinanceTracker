using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.Contracts
{
	public interface IUtilityRepository
	{
		public (ObservableCollection<string> months, string selectedMonth) GenerateMonthList();
	}
}
