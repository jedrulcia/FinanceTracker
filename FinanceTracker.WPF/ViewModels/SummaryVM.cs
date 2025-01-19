using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class SummaryVM
	{
		public int Balance { get; set; }
		public int Credits { get; set; }
		public int Charges { get; set; }
		public SummaryVM(int balance, int credits, int charges)
		{
			this.Balance = balance;
			this.Credits = credits;
			this.Charges = charges;
		}
	}
}
