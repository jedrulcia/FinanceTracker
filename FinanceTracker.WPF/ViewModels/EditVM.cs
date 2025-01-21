using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class EditVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }
		public int ExpenseTypeId { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public bool ExpenseTypeVisible { get; set; }
	}
}
