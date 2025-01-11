using FinanceTracker.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class SalaryVM
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }
		public DateTime Date { get; set; }
		public bool Paid { get; set; }

		public SalaryVM(Salary salary)
		{
			this.Id = salary.Id;
			this.Name = salary.Name;
			this.Value = salary.Value;
			this.Date = salary.Date;
			this.Paid = salary.Paid;
		}
	}
}
