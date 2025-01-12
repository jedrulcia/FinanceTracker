using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;

namespace FinanceTracker.WPF.Repositories
{
	public class OngoingExpenseTypesRepository : GenericRepository<OngoingExpenseTypes>, IOngoingExpenseTypesRepository
	{
		private readonly FinanceTrackerDbContext context;

		public OngoingExpenseTypesRepository(FinanceTrackerDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
