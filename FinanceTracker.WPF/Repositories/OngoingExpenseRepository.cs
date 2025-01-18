using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.WPF.Repositories
{
	public class OngoingExpenseRepository : GenericRepository<OngoingExpense>, IOngoingExpenseRepository
	{
		private readonly AppDbContext context;
		private IExpenseTypeRepository ongoingExpenseTypesRepository;

		public OngoingExpenseRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.context = context;
			this.ongoingExpenseTypesRepository = serviceProvider.GetRequiredService<IExpenseTypeRepository>();
		}

		public async Task<ObservableCollection<OngoingExpenseVM>> GetOngoingExpensesVMAsync(string month)
		{
			List<OngoingExpense> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<OngoingExpenseVM> listVM = new ObservableCollection<OngoingExpenseVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.OngoingExpenseTypeId);
				listVM.Add(new OngoingExpenseVM(item, type));
			}
			
			return listVM;
		}

		public async Task<ObservableCollection<OngoingExpenseVM>> GetOverdueOngoingExpensesVMAsync(string month)
		{
			var targetDate = DateTime.ParseExact(month, "MM-yyyy", null);
			List<OngoingExpense> list = (await GetAllAsync()).Where(x => x.Date < targetDate).ToList();
			ObservableCollection<OngoingExpenseVM> listVM = new ObservableCollection<OngoingExpenseVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.OngoingExpenseTypeId);
				listVM.Add(new OngoingExpenseVM(item, type));
			}

			return listVM;
		}
	}
}
