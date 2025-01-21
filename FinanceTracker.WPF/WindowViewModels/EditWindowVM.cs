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
		private IOngoingExpenseRepository ongoingExpenseRepository;
		private IOtherExpenseRepository otherExpenseRepository;
		public int Id { get; set; }
		public Module Module { get; set; }
		public EditWindowVM(IServiceProvider serviceProvider)
		{
			this.salaryRepository = serviceProvider.GetRequiredService<ISalaryRepository>();
			this.ongoingExpenseRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
			this.otherExpenseRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
		}

		private EditVM editVM;
		public EditVM EditVM
		{
			get => editVM;
			set
			{
				editVM = value;
				OnPropertyChanged();
			}
		}

		public async Task InitializeAsync(int Id, Module module)
		{
			this.Id = Id;
			this.Module = module;
			switch (this.Module)
			{
				case Module.Salary:
					EditVM = await salaryRepository.GetSalaryEditVMAsync(this.Id);
					break;
				case Module.OngoingExpense:
					EditVM = await ongoingExpenseRepository.GetOngoingExpenseEditVMAsync(this.Id);
					break;
				case Module.OtherExpense:
					EditVM = await otherExpenseRepository.GetOtherExpenseEditVMAsync(this.Id);
					break;
			}
		}

		public async Task EditEntityAsync()
		{
			switch (this.Module)
			{
				case Module.Salary:
					await salaryRepository.EditSalaryAsync(EditVM);
					break;
				case Module.OngoingExpense:
					await ongoingExpenseRepository.EditOngoingExpenseAsync(EditVM);
					break;
				case Module.OtherExpense:
					await otherExpenseRepository.EditOtherExpenseAsync(EditVM);
					break;
			}
		}
	}
}