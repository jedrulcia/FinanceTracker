using FinanceTracker.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.WPF.Base;

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
		public bool IsOngoing { get; set; }
		public Module Module { get; set; }

		public OverduePaymentVM(int? id, string name, int value, DateTime date, ExpenseType type, bool isOngoing, Module module)
		{
			this.Id = id;
			this.Name = name;
			this.Value = value;
			this.Date = date;
			this.Type = new ExpenseTypeVM(type);
			this.IsOngoing = isOngoing;
			this.Module = module;
		}
	}
}
