using FinanceTracker.WPF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceTracker.WPF.AppWindowFactory
{
	public interface IWindowFactory
	{
		T CreateWindow<T>(Module module, int id) where T : Window;
	}
}
