using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.WPF.ViewModels
{
    public class MonthVM
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public MonthVM(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
