using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceTracker.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	}


	public class MonthVM
	{
		public string DisplayDate { get; set; }
		public bool IsCurrentMonth { get; set; }
	}

	public class MainWindowVM
	{


		public ObservableCollection<MonthVM> months;
		public ObservableCollection<MonthVM> Months
		{
			get
			{
				return GenerateMonthList();
			}
		}

		public static ObservableCollection<MonthVM> GenerateMonthList()
		{
			var months = new ObservableCollection<MonthVM>();
			var currentYear = DateTime.Now.Year;
			var currentMonth = DateTime.Now.Month;

			for (int year = currentYear + 1; year >= currentYear - 1; year--)
			{
				for (int month = 12; month >= 1; month--)
				{
					months.Add(new MonthVM
					{
						DisplayDate = new DateTime(year, month, 1).ToString("MM-yyyy", CultureInfo.InvariantCulture),
						IsCurrentMonth = year == currentYear && month == currentMonth
					});
				}
			}

			return months;
		}
	}
}