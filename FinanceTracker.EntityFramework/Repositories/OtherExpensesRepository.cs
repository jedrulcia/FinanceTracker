
using FinanceTracker.Domain.Contracts;
using FinanceTracker.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.EntityFramework.Repositories
{
	public class OtherExpensesRepository : GenericRepository<OtherExpenses>, IOtherExpensesRepository
	{
		private readonly FinanceTrackerDbContext context;

		public OtherExpensesRepository(FinanceTrackerDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
