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
	}
}
