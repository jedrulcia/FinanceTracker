using FinanceTracker.WPF.Base.WindowFactory;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using FinanceTracker.WPF.Views;
using System.Diagnostics;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class MainWindow : Window
	{
		private readonly MainWindowVM MainWindowVM;
		private readonly IWindowFactory WindowFactory;

		public MainWindow(MainWindowVM mainVM, IWindowFactory windowFactory)
		{
			InitializeComponent();
			MainWindowVM = mainVM;
			DataContext = MainWindowVM;
			WindowFactory = windowFactory;
		}

		public async Task InitializeAsync()
		{
			await MainWindowVM.InitializeAsync();
			DataContext = MainWindowVM;
		}

		private async void OpenCreateModal_Click(object sender, RoutedEventArgs e)
		{
			CreateWindow createWindow = WindowFactory.CreateWindow<CreateWindow>();
			createWindow.ShowDialog();
			await MainWindowVM.RefreshMainViewAsync();
        }
    }
}