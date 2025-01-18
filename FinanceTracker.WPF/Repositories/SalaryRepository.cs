using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;

namespace FinanceTracker.WPF.Repositories
{
	public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
	{
		private readonly AppDbContext context;

		public SalaryRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
