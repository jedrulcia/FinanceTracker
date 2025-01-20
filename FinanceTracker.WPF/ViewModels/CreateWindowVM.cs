using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
    public class CreateWindowVM : ObservableObject
    {
        private ISalaryRepository salaryRepository {  get; set; }
        private IOngoingExpenseRepository ongoingExpenseRepository { get; set; }
        private IOtherExpenseRepository otherExpenseRepository { get; set; }
        public CreateWindowVM(IServiceProvider serviceProvider)
        {
            this.salaryRepository = serviceProvider.GetRequiredService<ISalaryRepository>();
            this.ongoingExpenseRepository = serviceProvider.GetRequiredService<IOngoingExpenseRepository>();
            this.otherExpenseRepository = serviceProvider.GetRequiredService<IOtherExpenseRepository>();
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

        public async Task CreateSalary()
        {
            await salaryRepository.CreateSalaryAsync(CreateVM);
            CreateVM = new CreateVM();
        }

        public async Task CreateOngoingExpense()
        {
            await ongoingExpenseRepository.CreateOngoingExpenseAsync(CreateVM);
            CreateVM = new CreateVM();
        }

        public async Task CreateOtherExpense()
        {
            await otherExpenseRepository.CreateOtherExpenseAsync(CreateVM);
            CreateVM = new CreateVM();
        }

    }
}
