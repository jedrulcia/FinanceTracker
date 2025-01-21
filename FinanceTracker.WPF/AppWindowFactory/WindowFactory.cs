using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceTracker.WPF.AppWindowFactory
{
	public class WindowFactory : IWindowFactory
	{
		private readonly IServiceProvider serviceProvider;

		public WindowFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public T CreateWindow<T>(Module module, int id) where T : Window
		{
			var window = serviceProvider.GetRequiredService<T>();

			if (window is EditWindow editWindow)
			{
				editWindow.Id = id;
				editWindow.Module = module;
			}

			return window;
		}
	}
}
