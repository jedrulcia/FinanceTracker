using FinanceTracker.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class OverduePaymentVM
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }
		public DateTime Date { get; set; }
		public bool Paid { get; set; }
		public ExpenseTypeVM Type { get; set; }

		public OverduePaymentVM(int? id, string name, int value, DateTime date, ExpenseType type)
		{
			this.Id = id;
			this.Name = name;
			this.Value = value;
			this.Date = date;
			this.Type = new ExpenseTypeVM(type);
		}
	}
}
