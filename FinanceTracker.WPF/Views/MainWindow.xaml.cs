using FinanceTracker.WPF.AppWindowFactory;
using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using FinanceTracker.WPF.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FinanceTracker.WPF
{
	public partial class MainWindow : Window
	{
		private readonly MainWindowVM MainWindowVM;
		private readonly IWindowFactory WindowFactory;

		public MainWindow(MainWindowVM mainVM, IWindowFactory windowFactory)
		{
			MainWindowVM = mainVM;
			DataContext = MainWindowVM;
			WindowFactory = windowFactory;
		}

		public async Task InitializeAsync()
		{
			await MainWindowVM.InitializeAsync();
			InitializeComponent();
		}

		private async void OpenCreateModal_Click(object sender, RoutedEventArgs e)
		{
			CreateWindow createWindow = WindowFactory.CreateWindow<CreateWindow>(Module.None, 0);
			createWindow.ShowDialog();
			await MainWindowVM.RefreshMainViewAsync();
        }

		private async void OpenEditSalaryModal_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button?.Tag is int id)
			{
				EditWindow editWindow = WindowFactory.CreateWindow<EditWindow>(Module.Salary, id);
				await editWindow.InitializeAsync();
				editWindow.ShowDialog();
				await MainWindowVM.RefreshMainViewAsync();
			}
		}

	}
}