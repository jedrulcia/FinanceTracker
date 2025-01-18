using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class MainWindow : Window
	{
		private readonly MainWindowVM MainWindowVM;

		public MainWindow(MainWindowVM mainVM)
		{
			InitializeComponent();
			MainWindowVM = mainVM;
			DataContext = MainWindowVM;
		}

		public async Task InitializeAsync()
		{
			await MainWindowVM.InitializeAsync();
			DataContext = MainWindowVM;
		}
	}
}