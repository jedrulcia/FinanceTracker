using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.EntityFramework
{
	public class FinanceTrackerDbContextFactory : IDesignTimeDbContextFactory<FinanceTrackerDbContext>
	{
		public FinanceTrackerDbContext CreateDbContext(string[] args = null)
		{
			DbContextOptionsBuilder<FinanceTrackerDbContext> options = new DbContextOptionsBuilder<FinanceTrackerDbContext>();
			options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FinanceTracker;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");

			return new FinanceTrackerDbContext(options.Options);
		}
	}
}
