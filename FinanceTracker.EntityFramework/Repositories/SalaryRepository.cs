
using FinanceTracker.Domain.Contracts;
using FinanceTracker.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.EntityFramework.Repositories
{
	public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
	{
		private readonly FinanceTrackerDbContext context;

		public SalaryRepository(FinanceTrackerDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
