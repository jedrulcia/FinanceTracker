using FinanceTracker.WPF.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FinanceTracker.WPF.Contracts
{
	public interface IUtilityRepository
	{
		public (ObservableCollection<string> months, string selectedMonth) GenerateMonthList();
		Task<SummaryVM> GetMonthlySummaryVMAsync(string month);
		Task<SummaryVM> GetYearlySummaryVMAsync(string month);
		Task<(ChartValues<int> charges, ChartValues<int> credits)> GetColumnChartVMsAsync(string month);
		Task<PieChartVM> GetPieChartVMAsync(string month);
	}
}
