using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MainVM : INotifyPropertyChanged
{

	private readonly IServiceProvider serviceProvider;
	private IOngoingExpensesRepository ongoingExpensesRepository { get; set; }
	private IOtherExpensesRepository otherExpensesRepository { get; set; }

	public MainVM(IServiceProvider serviceProvider)
	{
		this.serviceProvider = serviceProvider;
		this.ongoingExpensesRepository = serviceProvider.GetRequiredService<IOngoingExpensesRepository>();
		this.otherExpensesRepository = serviceProvider.GetRequiredService<IOtherExpensesRepository>();
	}

	private string selectedMonth;
	public string SelectedMonth
	{
		get => selectedMonth;
		set
		{
			selectedMonth = value;
			OnPropertyChanged();
			_ = RefreshOtherExpensesAsync();
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

	public ObservableCollection<string> Months { get; set; } = new ObservableCollection<string>();
	public async Task InitializeAsync()
	{
		(var months, var selected) = otherExpensesRepository.GenerateMonthList();
		foreach (var month in months)
		{
			Months.Add(month);
		}
		SelectedMonth = selected; // Wywoła automatyczne odświeżenie danych.
		await RefreshOtherExpensesAsync().ConfigureAwait(false);
	}

	private bool isBusy = false;
	private async Task RefreshOtherExpensesAsync()
	{
		if (isBusy)
			return;

		isBusy = true;
		try
		{
			// Pobierz dane i przypisz do kolekcji
			var expenses = await otherExpensesRepository.GetOtherExpensesVMAsync(SelectedMonth).ConfigureAwait(false);
			OtherExpensesVMs = new ObservableCollection<OtherExpensesVM>();
			foreach (var expense in expenses)
			{
				OtherExpensesVMs.Add(expense);
			}
		}
		finally
		{
			isBusy = false; // Zakończono operację
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
	private void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
