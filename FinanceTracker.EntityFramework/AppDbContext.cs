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
	public  class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ExpenseTypeSeedConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		DbSet<Salary> Salaries { get; set; }
		DbSet<OngoingExpense> OngoingExpenses { get; set; }
		DbSet<OtherExpense> OtherExpenses { get; set; }
		DbSet<ExpenseType> ExpenseTypes { get; set; }
	}
}
