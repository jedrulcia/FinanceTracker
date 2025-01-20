using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceTracker.WPF.Base.WindowFactory
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IServiceProvider serviceProvider;

		public WindowFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public T CreateWindow<T>() where T : Window
		{
			return serviceProvider.GetRequiredService<T>();
		}
	}
}
