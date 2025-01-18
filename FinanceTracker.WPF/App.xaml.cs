using FinanceTracker.EntityFramework;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.Repositories;
using FinanceTracker.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FinanceTracker.WPF
{
	public partial class App : Application
	{

		protected override async void OnStartup(StartupEventArgs e)
		{
			IServiceProvider serviceProvider = CreateServiceProvied();

			MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
			await mainWindow.InitializeAsync();
			mainWindow.Show();

			base.OnStartup(e);
		}

		private IServiceProvider CreateServiceProvied()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FinanceTracker;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"));

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IOngoingExpenseRepository, OngoingExpenseRepository>();
			services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
			services.AddScoped<ISalaryRepository, SalaryRepository>();
			services.AddScoped<IOtherExpenseRepository, OtherExpenseRepository>();
			services.AddScoped<IUtilityRepository, UtilityRepository>();

			services.AddScoped<MainWindowVM>();

			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowVM>()));

			return services.BuildServiceProvider();
		}
	}
}
