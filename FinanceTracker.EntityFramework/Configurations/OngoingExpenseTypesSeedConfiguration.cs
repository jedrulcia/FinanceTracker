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
	class OngoingExpenseTypesSeedConfiguration : IEntityTypeConfiguration<OngoingExpenseTypes>
	{
		public void Configure (EntityTypeBuilder<OngoingExpenseTypes> builder)
		{
			builder.HasData(
				new OngoingExpenseTypes { Id = 1, Name = "Jedzenie"},
				new OngoingExpenseTypes { Id = 2, Name = "Paliwo" },
				new OngoingExpenseTypes { Id = 3, Name = "Mieszkanie" },
				new OngoingExpenseTypes { Id = 4, Name = "Rachunki" },
				new OngoingExpenseTypes { Id = 5, Name = "Raty" },
				new OngoingExpenseTypes { Id = 6, Name = "Inne"}
				);
		}
	}
}
