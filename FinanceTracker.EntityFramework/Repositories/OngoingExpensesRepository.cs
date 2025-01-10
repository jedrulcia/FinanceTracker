using FinanceTracker.Domain.Contracts;
using FinanceTracker.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.EntityFramework.Repositories
{
	public class OngoingExpensesRepository : GenericRepository<OngoingExpenses>, IOngoingExpensesRepository
	{
		private readonly FinanceTrackerDbContext context;

		public OngoingExpensesRepository(FinanceTrackerDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
