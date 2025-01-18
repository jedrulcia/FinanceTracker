using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.WPF.Repositories
{
	public class OngoingExpensesRepository : GenericRepository<OngoingExpenses>, IOngoingExpensesRepository
	{
		private readonly AppDbContext context;
		private IOngoingExpenseTypesRepository ongoingExpenseTypesRepository;

		public OngoingExpensesRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.context = context;
			this.ongoingExpenseTypesRepository = serviceProvider.GetRequiredService<IOngoingExpenseTypesRepository>();
		}

		public async Task<ObservableCollection<OngoingExpensesVM>> GetOngoingExpensesVMAsync(string month)
		{
			List<OngoingExpenses> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<OngoingExpensesVM> listVM = new ObservableCollection<OngoingExpensesVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.OngoingExpenseTypesId);
				listVM.Add(new OngoingExpensesVM(item, type));
			}
			
			return listVM;
		}

		public async Task<ObservableCollection<OngoingExpensesVM>> GetOverdueOngoingExpensesVMAsync(string month)
		{
			var targetDate = DateTime.ParseExact(month, "MM-yyyy", null);
			List<OngoingExpenses> list = (await GetAllAsync()).Where(x => x.Date < targetDate).ToList();
			ObservableCollection<OngoingExpensesVM> listVM = new ObservableCollection<OngoingExpensesVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.OngoingExpenseTypesId);
				listVM.Add(new OngoingExpensesVM(item, type));
			}

			return listVM;
		}
	}
}
