using FinanceTracker.WPF.Contracts;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.EntityFramework;
using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.WPF.Repositories
{
	public class OngoingExpenseRepository : GenericRepository<OngoingExpense>, IOngoingExpenseRepository
	{
		private readonly AppDbContext context;
		private IExpenseTypeRepository ongoingExpenseTypesRepository;

		public OngoingExpenseRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.context = context;
			this.ongoingExpenseTypesRepository = serviceProvider.GetRequiredService<IExpenseTypeRepository>();
		}

		public async Task<ObservableCollection<OngoingExpenseVM>> GetOngoingExpenseVMsAsync(string month)
		{
			List<OngoingExpense> list = (await GetAllAsync()).Where(x => x.Date.ToString("MM-yyyy") == month).ToList();
			ObservableCollection<OngoingExpenseVM> listVM = new ObservableCollection<OngoingExpenseVM>();

			foreach (var item in list)
			{
				var type = await ongoingExpenseTypesRepository.GetAsync(item.ExpenseTypeId);
				listVM.Add(new OngoingExpenseVM(item, type));
			}
			
			return listVM;
		}

		public async Task CreateOngoingExpenseAsync(CreateVM createVM)
		{
			OngoingExpense ongoingExpense = new OngoingExpense
			{
				Name = createVM.Name,
				Value = createVM.Value,
				Date = createVM.Date,
				Paid = false,
				ExpenseTypeId = createVM.ExpenseTypeId,
			};
			await AddAsync(ongoingExpense);
		}

		public async Task<EditVM> GetOngoingExpenseEditVMAsync(int id)
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

		public async Task EditOngoingExpenseAsync(EditVM editVM)
		{
			var expense = await GetAsync(editVM.Id);

			expense.Name = editVM.Name;
			expense.Value = editVM.Value;
			expense.Date = editVM.Date;
			expense.ExpenseTypeId = editVM.ExpenseTypeId;

			await UpdateAsync(expense);
		}
	}
}
