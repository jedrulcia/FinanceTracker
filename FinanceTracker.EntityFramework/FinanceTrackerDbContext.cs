using FinanceTracker.EntityFramework.Data;
using FinanceTracker.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.EntityFramework
{
	public  class FinanceTrackerDbContext : DbContext
	{
		public FinanceTrackerDbContext(DbContextOptions options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new OngoingExpenseTypesSeedConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		DbSet<Salary> Salary { get; set; }
		DbSet<OngoingExpenses> OngoingExpenses { get; set; }
		DbSet<OtherExpenses> OtherExpenses { get; set; }
		DbSet<OngoingExpenseTypes> OngoingExpenseTypes { get; set; }

	}
}
