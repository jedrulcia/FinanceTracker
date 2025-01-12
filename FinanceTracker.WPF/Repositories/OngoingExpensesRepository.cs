using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;

namespace FinanceTracker.WPF.Repositories
{
	public class OngoingExpensesRepository : GenericRepository<OngoingExpenses>, IOngoingExpensesRepository
	{
		private readonly FinanceTrackerDbContext context;
		private IOngoingExpenseTypesRepository ongoingExpenseTypesRepository;

		public OngoingExpensesRepository(FinanceTrackerDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<List<OngoingExpensesVM>> GetOngoingExpensesVMAsync(string month)
		{
			List<OngoingExpenses> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			List<OngoingExpensesVM> listVM = new List<OngoingExpensesVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.OngoingExpenseTypesId);
				listVM.Add(new OngoingExpensesVM(item, type));
			}
			
			return listVM;
		}
	}
}
