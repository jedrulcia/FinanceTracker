using FinanceTracker.WPF.Base;
using FinanceTracker.WPF.WindowViewModels;
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
	/// <summary>
	/// Logika interakcji dla klasy EditWindow.xaml
	/// </summary>
	public partial class EditWindow : Window
	{
		public int Id { get; set; }
		public Module Module { get; set; }
		public EditWindowVM EditWindowVM;
		public EditWindow(EditWindowVM editWindowVM)
		{
			InitializeComponent();
			EditWindowVM = editWindowVM;
			DataContext = EditWindowVM;
		}

		public async Task InitializeAsync()
		{
			await EditWindowVM.InitializeAsync(Id, Module);
		}

		private async void EditEntity_Click(object sender, RoutedEventArgs e)
		{
			await EditWindowVM.EditEntityAsync();
			this.Close();
		}
	}
}
