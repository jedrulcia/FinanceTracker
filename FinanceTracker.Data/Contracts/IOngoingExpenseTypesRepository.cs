using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Domain.Data;

namespace FinanceTracker.Domain.Contracts
{
	public interface IOngoingExpenseTypesRepository : IGenericRepository<OngoingExpenseTypes>
	{
	}
}
