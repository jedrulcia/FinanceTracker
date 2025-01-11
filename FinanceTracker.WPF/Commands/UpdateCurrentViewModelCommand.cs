using FinanceTracker.WPF.State;
using FinanceTracker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceTracker.WPF.Commands
{
	public class UpdateCurrentViewModelCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;
		public INavigator navigator;

		public UpdateCurrentViewModelCommand(INavigator navigator)
		{
			this.navigator = navigator;
		}

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			if (parameter is string date)
			{
				DateTime dateTime = DateTime.ParseExact(date, "MM-yyyy", CultureInfo.InvariantCulture);
				navigator.HomeViewModel = new HomeViewModel(dateTime);
			}
			else
			{
				throw new ArgumentException("Parameter must be of type DateTime", nameof(parameter));
			}
		}
	}
}
