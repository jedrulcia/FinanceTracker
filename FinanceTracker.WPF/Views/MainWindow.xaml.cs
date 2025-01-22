﻿using FinanceTracker.WPF.AppWindowFactory;
using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using FinanceTracker.WPF.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
			var button = sender as Grid;
			if (button?.Tag is int id)
			{
				EditWindow editWindow = WindowFactory.CreateWindow<EditWindow>(Module.Salary, id);
				await editWindow.InitializeAsync();
				editWindow.ShowDialog();
				await MainWindowVM.RefreshMainViewAsync();
			}
		}

		private async void OpenEditOngoingExpenseModal_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Grid;
			if (button?.Tag is int id)
			{
				EditWindow editWindow = WindowFactory.CreateWindow<EditWindow>(Module.OngoingExpense, id);
				await editWindow.InitializeAsync();
				editWindow.ShowDialog();
				await MainWindowVM.RefreshMainViewAsync();
			}
		}

		private async void OpenEditOtherExpenseModal_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Grid;
			if (button?.Tag is int id)
			{
				EditWindow editWindow = WindowFactory.CreateWindow<EditWindow>(Module.OtherExpense, id);
				await editWindow.InitializeAsync();
				editWindow.ShowDialog();
				await MainWindowVM.RefreshMainViewAsync();
			}
		}
		private void OnGridMouseDown(object sender, MouseButtonEventArgs e)
		{
			var grid = sender as Grid;
			if (grid == null) return;

			// Pobierz wartość 'Module' z Tag przypisanego do Grid
			var module = grid.Tag as string;

			// Sprawdź, który moduł jest przypisany
			if (module == "OngoingExpense")
			{
				// Wywołaj odpowiednią metodę dla OngoingExpense
				OpenEditOngoingExpenseModal_Click(sender, e);
			}
			else if (module == "OtherExpense")
			{
				// Wywołaj odpowiednią metodę dla OtherExpense
				OpenEditOtherExpenseModal_Click(sender, e);
			}
		}

		private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}