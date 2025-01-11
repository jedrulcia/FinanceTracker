using FinanceTracker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceTracker.WPF.State
{
	public interface INavigator
	{
		public HomeViewModel HomeViewModel { get; set; }
		ICommand UpdateCurrentViewModelCommand { get; }
	}
}
