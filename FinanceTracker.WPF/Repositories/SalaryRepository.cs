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

		public async Task CreateSalaryAsync(CreateVM createVM)
		{
			Salary salary = new Salary
			{
				Name = createVM.Name,
				Value = createVM.Value,
				Date = createVM.Date,
				Paid = false
			};
			await AddAsync(salary);
		}

		public async Task<EditVM> GetSalaryEditVMAsync(int id)
		{
			var salary = await GetAsync(id);

			EditVM editVM = new EditVM
			{
				Id = id,
				Name = salary.Name,
				Value = salary.Value,
				Date = salary.Date,
				ExpenseTypeVisible = false
			};

			return editVM;
		}

		public async Task EditSalaryAsync(EditVM editVM)
		{
			var salary = await GetAsync(editVM.Id);

			salary.Name = editVM.Name;
			salary.Value = editVM.Value;
			salary.Date = editVM.Date;

			await UpdateAsync(salary);
		}
	}
}
