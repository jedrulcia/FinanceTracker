using FinanceTracker.EntityFramework.Data;
using FinanceTracker.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace FinanceTracker.WPF.Contracts
{
    public interface ISalaryRepository : IGenericRepository<Salary>
    {
        Task<ObservableCollection<SalaryVM>> GetSalaryVMsAsync(string month);
        Task CreateSalaryAsync(CreateVM createVM);
        Task<EditVM> GetSalaryEditVMAsync(int id);
        Task EditSalaryAsync(EditVM editVM);
        Task ChangeSalaryStatusAsync(int id);
		Task DeleteSalaryAsync(int id);
	}
}
