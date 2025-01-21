using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.Contracts;
using FinanceTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.WindowViewModels
{
	public class EditWindowVM : ObservableObject
	{
		private ISalaryRepository salaryRepository;
		public int Id { get; set; }
		public Module Module { get; set; }
		public EditWindowVM(IServiceProvider serviceProvider)
		{
			this.salaryRepository = serviceProvider.GetRequiredService<ISalaryRepository>();
		}

		private EditVM editVM = new EditVM();
		public EditVM EditVM
		{
			get => editVM;
			set
			{
				editVM = value;
				OnPropertyChanged();
			}
		}

		public async Task InitializeAsync()
		{
			switch (this.Module)
			{
				case Module.Salary:
					break;
				case Module.OngoingExpense:
					break;
				case Module.OtherExpense:
					break;
			}
		}
	}
}