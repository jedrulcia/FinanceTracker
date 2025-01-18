using FinanceTracker.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class ExpenseTypeVM
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ExpenseTypeVM(ExpenseType ongoingExpenseType)
		{
			this.Id = ongoingExpenseType.Id;
			this.Name = ongoingExpenseType.Name;
		}
	}
}
