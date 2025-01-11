using FinanceTracker.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class OngoingExpensesVM
	{
		public int? Id { get; set; }
		public OngoingExpenseTypesVM Type { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }
		public DateTime Date { get; set; }
		public bool Paid { get; set; }

		public OngoingExpensesVM(OngoingExpenses ongoingExpenses, OngoingExpenseTypes type)
		{
			this.Id = ongoingExpenses.Id;
			this.Type = new OngoingExpenseTypesVM(type);
			this.Name = ongoingExpenses.Name;
			this.Value = ongoingExpenses.Value;
			this.Date = ongoingExpenses.Date;
			this.Paid = ongoingExpenses.Paid;
		}
	}
}
