using FinanceTracker.WPF.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{

	public class MainVM
	{
		public INavigator Navigator { get; set; } = new Navigator();
	}
}
