using FinanceTracker.WPF.Commands;
using FinanceTracker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceTracker.WPF.State
{
	public class Navigator : INavigator
	{
		public HomeViewModel HomeViewModel { get; set; }
		public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
	}
}
