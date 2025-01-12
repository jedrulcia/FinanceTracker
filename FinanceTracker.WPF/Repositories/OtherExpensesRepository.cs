using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;

namespace FinanceTracker.WPF.Repositories
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
