﻿using FinanceTracker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.Contracts
{
	public interface IUtilityRepository
	{
		public (ObservableCollection<string> months, string selectedMonth) GenerateMonthList();
		Task<ObservableCollection<OverduePaymentVM>> GetOverduePaymentVMsAsync(string month);
		Task<SummaryVM> GetMonthlySummaryVMAsync(string month);
		Task<SummaryVM> GetYearlySummaryVMAsync(string month);
	}
}
