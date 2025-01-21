using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

public class MainWindowVM : ObservableObject
{
	// Dependency injection through service provider
	private IOngoingExpenseRepository ongoingExpensesRepository { get; set; }
	private IOtherExpenseRepository otherExpensesRepository { get; set; }
	private IUtilityRepository utilityRepository { get; set; }
	private ISalaryRepository salaryRepository { get; set; }

	public MainWindowVM(IServiceProvider serviceProvider)
	{
		this.ongoingExpensesRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
		this.otherExpensesRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
		this.utilityRepository = serviceProvider.GetRequiredService<IUtilityRepository>();
		this.salaryRepository = serviceProvider.GetRequiredService<ISalaryRepository>();
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

	private ObservableCollection<OngoingExpenseVM> ongoingExpenseVMs;
	public ObservableCollection<OngoingExpenseVM> OngoingExpenseVMs
	{
		get => ongoingExpenseVMs;
		set
		{
			ongoingExpenseVMs = value;
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

	private ObservableCollection<SalaryVM> salaryVMs;
	public ObservableCollection<SalaryVM> SalaryVMs
	{
		get => salaryVMs;
		set
		{
			salaryVMs = value;
			OnPropertyChanged();
		}
	}

	private SummaryVM monthlySummaryVM;
	public SummaryVM MonthlySummaryVM
	{
		get => monthlySummaryVM;
		set
		{
			monthlySummaryVM = value;
			OnPropertyChanged();
		}
	}

	private SummaryVM yearlySummaryVM;
	public SummaryVM YearlySummaryVM
	{
		get => yearlySummaryVM;
		set
		{
			yearlySummaryVM = value;
			OnPropertyChanged();
		}
	}

	private ChartValues<int> columnChartCredits;
	public ChartValues<int> ColumnChartCredits
	{
		get => columnChartCredits;
		set
		{
			columnChartCredits = value;
			OnPropertyChanged();
		}
	}

	private ChartValues<int> columnChartCharges;
	public ChartValues<int> ColumnChartCharges
	{
		get => columnChartCharges;
		set
		{
			columnChartCharges = value;
			OnPropertyChanged();
		}
	}

	private PieChartVM pieChartVM;
	public PieChartVM PieChartVM
	{
		get => pieChartVM;
		set
		{
			pieChartVM = value;
			OnPropertyChanged();
		}
	}

	// Initialize method
	public async Task InitializeAsync()
	{
		(var months, SelectedMonth) = utilityRepository.GenerateMonthList();
		foreach (var month in months) Months.Add(month);
		await RefreshMainViewAsync();
	}

	// Refresh method
	private bool isBusy = false;
	public async Task RefreshMainViewAsync()
	{
		if (isBusy) return;
		isBusy = true;

		try
		{
			PieChartVM = await utilityRepository.GetPieChartVMAsync(SelectedMonth);
			(ColumnChartCredits, ColumnChartCharges) = await utilityRepository.GetColumnChartVMsAsync(SelectedMonth);
			OtherExpenseVMs = await otherExpensesRepository.GetOtherExpenseVMsAsync(SelectedMonth);
			OngoingExpenseVMs = await ongoingExpensesRepository.GetOngoingExpenseVMsAsync(SelectedMonth);
			OverduePaymentVMs = await utilityRepository.GetOverduePaymentVMsAsync(SelectedMonth);
			SalaryVMs = await salaryRepository.GetSalaryVMsAsync(SelectedMonth);
			MonthlySummaryVM = await utilityRepository.GetMonthlySummaryVMAsync(SelectedMonth);
			YearlySummaryVM = await utilityRepository.GetYearlySummaryVMAsync(SelectedMonth);
		}
		catch { }
		finally { isBusy = false; }
	}
}
