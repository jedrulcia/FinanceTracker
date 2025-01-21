using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.WPF.Repositories
{
	public class OtherExpenseRepository : GenericRepository<OtherExpense>, IOtherExpenseRepository
	{
		private readonly AppDbContext context;
		private IExpenseTypeRepository ongoingExpenseTypesRepository;

		public OtherExpenseRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.context = context;
			this.ongoingExpenseTypesRepository = serviceProvider.GetRequiredService<IExpenseTypeRepository>();
		}

		public async Task<ObservableCollection<OtherExpenseVM>> GetOtherExpenseVMsAsync(string month)
		{
			List<OtherExpense> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<OtherExpenseVM> listVM = new ObservableCollection<OtherExpenseVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.ExpenseTypeId);
				listVM.Add(new OtherExpenseVM(item, type));
			}
			return listVM;
		}

		public async Task CreateOtherExpenseAsync(CreateVM createVM)
		{
			OtherExpense otherExpense = new OtherExpense
			{
				Name = createVM.Name,
				Value = createVM.Value,
				Date = createVM.Date,
				Paid = false,
				ExpenseTypeId = createVM.ExpenseTypeId,
			};
			await AddAsync(otherExpense);
		}

		public async Task<EditVM> GetOtherExpenseEditVMAsync(int id)
		{
			var expense = await GetAsync(id);

			EditVM editVM = new EditVM
			{
				Id = id,
				Name = expense.Name,
				Value = expense.Value,
				Date = expense.Date,
				ExpenseTypeId = expense.ExpenseTypeId,
				ExpenseTypeVisible = true
			};

			return editVM;
		}

		public async Task EditOtherExpenseAsync(EditVM editVM)
		{
			var expense = await GetAsync(editVM.Id);

			expense.Name = editVM.Name;
			expense.Value = editVM.Value;
			expense.Date = editVM.Date;
			expense.ExpenseTypeId = editVM.ExpenseTypeId;

			await UpdateAsync(expense);
		}

		public async Task ChangeOtherExpenseStatusAsync(int id)
		{
			var expense = await GetAsync(id);
			expense.Paid = !expense.Paid;
			await UpdateAsync(expense);
		}

		public async Task DeleteOtherExpenseAsync(int id)
		{
			await DeleteAsync(id);
		}
	}
}
