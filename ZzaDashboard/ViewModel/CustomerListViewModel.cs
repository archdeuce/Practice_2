using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    public class CustomerListViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        private Customer Customer { get; set; }
        public Customer SelectedCustomer { get; set; }
        public ICustomersRepository CustomerRepository { get; set; }
        public ICommand ShowCommand { get; set; }

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.CustomerRepository = new CustomersRepository();
            this.ShowCommand = new RelayCommand(ShowCommandExecuted, ShowCommandCanExecute);
            this.Customers = new ObservableCollection<Customer>();

            this.GetCustomers();
        }

        public void ShowCommandExecuted(object obj)
        {
            this.GetCustomers();
        }

        public bool ShowCommandCanExecute(object obj)
        {
            return true;
        }

        private async void GetCustomers()
        {
            var customersList = await this.CustomerRepository.GetCustomersAsync();

            foreach (var customer in customersList)
            {
                this.Customers.Add(customer);
            }
        }
    }
}
