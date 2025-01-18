using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using System.Collections.ObjectModel;
using FinanceTracker.WPF.ViewModels;

namespace FinanceTracker.WPF.Repositories
{
	public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
	{
		private readonly AppDbContext context;

		public SalaryRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<ObservableCollection<SalaryVM>> GetSalaryVMsAsync(string month)
		{
			List<Salary> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<SalaryVM> listVM = new ObservableCollection<SalaryVM>();

			foreach (var item in list)
			{
				listVM.Add(new SalaryVM(item));
			}

			return listVM;
		}
	}
}
