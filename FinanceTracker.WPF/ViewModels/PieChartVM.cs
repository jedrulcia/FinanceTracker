using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class PieChartVM
	{
		public ChartValues<ObservableValue> Food { get; set; }
		public ChartValues<ObservableValue> Fuel { get; set; }
		public ChartValues<ObservableValue> Flat { get; set; }
		public ChartValues<ObservableValue> Bills { get; set; }
		public ChartValues<ObservableValue> Rates { get; set; }
		public ChartValues<ObservableValue> Other { get; set; }
		public Func<ChartPoint, string> LabelFormatter => point => point.Y > 0 ? ((int)point.Y).ToString() : string.Empty;
		public PieChartVM(List<ChartValues<ObservableValue>> result)
		{
			this.Food = result[0];
			this.Fuel = result[1];
			this.Flat = result[2];
			this.Bills = result[3];
			this.Rates = result[4];
			this.Other = result[5];
		}
	}
}
