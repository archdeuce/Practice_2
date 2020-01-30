using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_01_25_cw.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }

        public MainWindowViewModel()
        {
            this.Customers = new ObservableCollection<Customer>() { 
            
                new Customer("Elena", "Zub", "Kharkiv"),
                new Customer("Roman", "Sokolenko", "Kharkiv"),
                new Customer("Tanya", "Ryzhik", "Kharkiv")
            };
        }
    }
}
