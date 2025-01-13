using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class MainWindow : Window
	{
		private readonly MainVM MainVM;

		public MainWindow(MainVM mainVM)
		{
			InitializeComponent();
			MainVM = mainVM;
			DataContext = MainVM;
		}

		public async Task InitializeAsync()
		{
			await MainVM.InitializeAsync();
			DataContext = MainVM;
		}
	}
}