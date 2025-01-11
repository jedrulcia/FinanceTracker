using FinanceTracker.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
	public class OngoingExpenseTypesVM
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public OngoingExpenseTypesVM(OngoingExpenseTypes ongoingExpenseType)
		{
			this.Id = ongoingExpenseType.Id;
			this.Name = ongoingExpenseType.Name;
		}
	}
}
