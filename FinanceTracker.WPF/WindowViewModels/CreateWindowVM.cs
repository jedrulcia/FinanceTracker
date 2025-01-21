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
	public class CreateWindowVM : ObservableObject
	{
		private ISalaryRepository salaryRepository { get; set; }
		private IOngoingExpenseRepository ongoingExpenseRepository { get; set; }
		private IOtherExpenseRepository otherExpenseRepository { get; set; }
		public CreateWindowVM(IServiceProvider serviceProvider)
		{
			salaryRepository = serviceProvider.GetRequiredService<ISalaryRepository>();
			ongoingExpenseRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
			otherExpenseRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
		}

		private CreateVM createVM = new CreateVM();
		public CreateVM CreateVM
		{
			get => createVM;
			set
			{
				createVM = value;
				OnPropertyChanged();
			}
		}

		public async Task CreateEntity(Module module)
		{
			switch (module)
			{
				case Module.Salary:
					await salaryRepository.CreateSalaryAsync(CreateVM);
					break;
				case Module.OngoingExpense:
					await ongoingExpenseRepository.CreateOngoingExpenseAsync(CreateVM);
					break;
				case Module.OtherExpense:
					await otherExpenseRepository.CreateOtherExpenseAsync(CreateVM);
					break;
			}
			CreateVM = new CreateVM();
		}

	}
}
