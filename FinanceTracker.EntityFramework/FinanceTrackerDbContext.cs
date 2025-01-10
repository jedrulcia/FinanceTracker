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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FinanceTracker;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");

			base.OnConfiguring(optionsBuilder);
		}
	}
}
