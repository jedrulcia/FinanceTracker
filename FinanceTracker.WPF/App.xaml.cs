using FinanceTracker.WPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class App : Application
	{
		protected async override void OnStartup(StartupEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			await mainWindow.InitializeAsync();
			mainWindow.Show();

			base.OnStartup(e);
		}
	}
}
