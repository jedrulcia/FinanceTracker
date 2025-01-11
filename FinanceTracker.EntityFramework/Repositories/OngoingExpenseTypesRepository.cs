using FinanceTracker.Domain.Contracts;
using FinanceTracker.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.EntityFramework.Repositories
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
