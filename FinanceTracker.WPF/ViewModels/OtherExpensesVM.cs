using FinanceTracker.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class OtherExpensesVM
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }
		public DateTime Date { get; set; }
		public bool Paid { get; set; }

		public OtherExpensesVM(OtherExpenses otherExpenses)
		{
			this.Id = otherExpenses.Id;
			this.Name = otherExpenses.Name;
			this.Value = otherExpenses.Value;
			this.Date = otherExpenses.Date;
			this.Paid = otherExpenses.Paid;
		}
	}
}
