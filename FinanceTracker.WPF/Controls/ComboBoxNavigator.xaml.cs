using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceTracker.WPF.Controls
{
	/// <summary>
	/// Logika interakcji dla klasy ComboBoxNavigator.xaml
	/// </summary>
	public partial class ComboBoxNavigator : UserControl, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ObservableCollection<string> Months { get; set; }

		public ComboBoxNavigator()
		{
			InitializeComponent();
			DataContext = this;
			Months = GenerateMonthList();
		}

		private ObservableCollection<string> GenerateMonthList()
		{
			var months = new ObservableCollection<string>();

			var currentYear = DateTime.Now.Year;
			var currentMonth = DateTime.Now.Month;

			for (int year = currentYear + 1; year >= currentYear - 1; year--)
			{
				for (int month = 12; month >= 1; month--)
				{
					var newMonth = new DateTime(year, month, 1).ToString("MM-yyyy", CultureInfo.InvariantCulture);
					months.Add((newMonth));
				}
			}

			return months;
		}
	}
}
