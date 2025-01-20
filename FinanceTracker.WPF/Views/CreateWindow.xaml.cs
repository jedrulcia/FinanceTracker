using FinanceTracker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinanceTracker.WPF.Views
{
    public partial class CreateWindow : Window
    {
        private readonly CreateWindowVM CreateWindowVM;
        public CreateWindow(CreateWindowVM createWindowVM)
        {
            InitializeComponent();
            CreateWindowVM = createWindowVM;
            DataContext = CreateWindowVM;
		}

        private async void CreateSalary_Click(object sender, RoutedEventArgs e)
		{
			await CreateWindowVM.CreateSalary();
			this.Close();
		}

		private async void CreateOngoingExpense_Click(object sender, RoutedEventArgs e)
		{
			await CreateWindowVM.CreateOngoingExpense();
			this.Close();
		}

		private async void CreateOtherExpense_Click(object sender, RoutedEventArgs e)
		{
			await CreateWindowVM.CreateOtherExpense();
			this.Close();
		}
	}
}
