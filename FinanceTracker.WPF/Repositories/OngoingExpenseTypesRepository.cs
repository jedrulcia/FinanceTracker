using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;

namespace FinanceTracker.WPF.Repositories
{
	public class OngoingExpenseTypesRepository : GenericRepository<OngoingExpenseTypes>, IOngoingExpenseTypesRepository
	{
		private readonly AppDbContext context;

		public OngoingExpenseTypesRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<OngoingExpenseTypesVM> GetOngoingExpenseTypeVM(int id)
		{
			var type = await GetAsync(id);
			return new OngoingExpenseTypesVM(type);
		}
	}
}
