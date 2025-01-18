using FinanceTracker.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.EntityFramework.Configurations
{ 
	class ExpenseTypeSeedConfiguration : IEntityTypeConfiguration<ExpenseType>
	{
		public void Configure (EntityTypeBuilder<ExpenseType> builder)
		{
			builder.HasData(
				new ExpenseType { Id = 1, Name = "Jedzenie"},
				new ExpenseType { Id = 2, Name = "Paliwo" },
				new ExpenseType { Id = 3, Name = "Mieszkanie" },
				new ExpenseType { Id = 4, Name = "Rachunki" },
				new ExpenseType { Id = 5, Name = "Raty" },
				new ExpenseType { Id = 6, Name = "Inne"}
				);
		}
	}
}
