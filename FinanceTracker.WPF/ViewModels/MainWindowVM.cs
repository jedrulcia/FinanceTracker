using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MainWindowVM : ObservableObject
{
	// Dependency injection through service provider
	private IOngoingExpenseRepository ongoingExpensesRepository { get; set; }
	private IOtherExpenseRepository otherExpensesRepository { get; set; }
	private IUtilityRepository utilityRepository { get; set; }

	public MainWindowVM(IServiceProvider serviceProvider)
	{
		this.ongoingExpensesRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
		this.otherExpensesRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
		this.utilityRepository = serviceProvider.GetRequiredService<IUtilityRepository>();
	}

	// Properties
	public ObservableCollection<string> Months { get; set; } = new ObservableCollection<string>();

	private string selectedMonth;
	public string SelectedMonth
	{
		get => selectedMonth;
		set
		{
			selectedMonth = value;
			OnPropertyChanged();
			_ = RefreshMainViewAsync();
		}
	}

	private ObservableCollection<OtherExpenseVM> otherExpenseVMs;
	public ObservableCollection<OtherExpenseVM> OtherExpenseVMs
	{
		get => otherExpenseVMs;
		set
		{
			otherExpenseVMs = value;
			OnPropertyChanged();
		}
	}

	private ObservableCollection<OngoingExpenseVM> ongoingExpensesVMs;
	public ObservableCollection<OngoingExpenseVM> OngoingExpensesVMs
	{
		get => ongoingExpensesVMs;
		set
		{
			ongoingExpensesVMs = value;
			OnPropertyChanged();
		}
	}

	private ObservableCollection<OverduePaymentVM> overduePaymentVMs;
	public ObservableCollection<OverduePaymentVM> OverduePaymentVMs
	{
		get => overduePaymentVMs;
		set
		{
			overduePaymentVMs = value;
			OnPropertyChanged();
		}
	}

	// Initialize method
	public async Task InitializeAsync()
	{
		(var months, SelectedMonth) = utilityRepository.GenerateMonthList();
		foreach (var month in months) Months.Add(month);
		await RefreshMainViewAsync().ConfigureAwait(false);
	}

	// Refresh method
	private bool isBusy = false;
	private async Task RefreshMainViewAsync()
	{
		if (isBusy) return;
		isBusy = true;

		try
		{
			OtherExpenseVMs = await otherExpensesRepository.GetOtherExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
			OngoingExpensesVMs = await ongoingExpensesRepository.GetOngoingExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
			OverduePaymentVMs = await utilityRepository.GenerateOverduePaymentVMsAsync(SelectedMonth).ConfigureAwait(false);
		}
		catch { }
		finally { isBusy = false; }
	}
}
