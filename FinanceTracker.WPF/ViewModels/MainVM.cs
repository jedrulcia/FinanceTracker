using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MainVM : ObservableObject
{
	private IOngoingExpensesRepository ongoingExpensesRepository { get; set; }
	private IOtherExpensesRepository otherExpensesRepository { get; set; }
	private IUtilityRepository utilityRepository { get; set; }

	public MainVM(IServiceProvider serviceProvider)
	{
		this.ongoingExpensesRepository = serviceProvider.GetRequiredService<IOngoingExpensesRepository>();
		this.otherExpensesRepository = serviceProvider.GetRequiredService<IOtherExpensesRepository>();
		this.utilityRepository = serviceProvider.GetRequiredService<IUtilityRepository>();
	}

	public ObservableCollection<string> Months { get; set; } = new ObservableCollection<string>();

	private string selectedMonth;
	public string SelectedMonth
	{
		get => selectedMonth;
		set
		{
			selectedMonth = value;
			OnPropertyChanged();
			_ = RefreshMainView();
		}
	}

	private ObservableCollection<OtherExpensesVM> otherExpensesVMs;
	public ObservableCollection<OtherExpensesVM> OtherExpensesVMs
	{
		get => otherExpensesVMs;
		set
		{
			otherExpensesVMs = value;
			OnPropertyChanged();
		}
	}

	private ObservableCollection<OngoingExpensesVM> ongoingExpensesVMs;
	public ObservableCollection<OngoingExpensesVM> OngoingExpensesVMs
	{
		get => ongoingExpensesVMs;
		set
		{
			ongoingExpensesVMs = value;
			OnPropertyChanged();
		}
	}

	private ObservableCollection<OtherExpensesVM> overdueOtherExpensesVMs;
	public ObservableCollection<OtherExpensesVM> OverdueOtherExpensesVMs
	{
		get => overdueOtherExpensesVMs;
		set
		{
			overdueOtherExpensesVMs = value;
			OnPropertyChanged();
		}
	}

	private ObservableCollection<OngoingExpensesVM> overdueOngoingExpensesVMs;
	public ObservableCollection<OngoingExpensesVM> OverdueOngoingExpensesVMs
	{
		get => overdueOngoingExpensesVMs;
		set
		{
			overdueOngoingExpensesVMs = value;
			OnPropertyChanged();
		}
	}

	public async Task InitializeAsync()
	{
		(var months, var selected) = utilityRepository.GenerateMonthList();
		foreach (var month in months)
		{
			Months.Add(month);
		}
		SelectedMonth = selected; // Wywoła automatyczne odświeżenie danych.
		await RefreshMainView().ConfigureAwait(false);
	}

	private bool isBusy = false;
	private async Task RefreshMainView()
	{
		if (isBusy)
			return;

		isBusy = true;
		try
		{
			OtherExpensesVMs = await otherExpensesRepository.GetOtherExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
			OngoingExpensesVMs = await ongoingExpensesRepository.GetOngoingExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
			OverdueOngoingExpensesVMs = await ongoingExpensesRepository.GetOverdueOngoingExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
			OverdueOtherExpensesVMs = await otherExpensesRepository.GetOverdueOtherExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
		}
		catch
		{

		}
		finally
		{
			isBusy = false;
		}
	}
}
