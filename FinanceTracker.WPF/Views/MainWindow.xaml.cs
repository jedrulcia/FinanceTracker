using FinanceTracker.WPF.ViewModels;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class MainWindow : Window
	{
		public MainVM MainVM { get; set; } = new MainVM();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
		}

		public async Task InitializeAsync()
		{
			await MainVM.InitializeAsync();
		}

		private void ChangeView_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}