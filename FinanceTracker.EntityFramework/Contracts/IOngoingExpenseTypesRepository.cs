using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Domain.Data;

namespace FinanceTracker.EntityFramework.Contracts
{
	public interface IOngoingExpenseTypesRepository : IGenericRepository<OngoingExpenseTypes>
	{
	}
}
