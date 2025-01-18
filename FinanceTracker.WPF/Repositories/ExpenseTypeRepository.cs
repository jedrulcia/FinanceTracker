using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;

namespace FinanceTracker.WPF.Repositories
{
	public class ExpenseTypeRepository : GenericRepository<ExpenseType>, IExpenseTypeRepository
	{
		private readonly AppDbContext context;

		public ExpenseTypeRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<ExpenseTypeVM> GetOngoingExpenseTypeVM(int id)
		{
			var type = await GetAsync(id);
			return new ExpenseTypeVM(type);
		}
	}
}
