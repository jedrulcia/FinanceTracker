using System.Configuration;
using System.Data;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow window = new MainWindow();
			window.Show();

			base.OnStartup(e);
		}
	}
}
