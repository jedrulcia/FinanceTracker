using FinanceTracker.Domain.Data;
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
		DbSet<Salary> Salary {  get; set; }
		DbSet<OngoingExpenses> OngoingExpenses { get; set; }
		DbSet<OtherExpenses> OtherExpenses { get; set; }
		public FinanceTrackerDbContext(DbContextOptions options) : base(options){ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
