using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    public class CustomerEditViewModel
    {
        public Customer Customer { get; set; }
        public ICustomersRepository CustomerRepository { get; set; }
        public ICommand SaveCommand { get; set; }

        public CustomerEditViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.CustomerRepository = new CustomersRepository();
            this.Customer = this.CustomerRepository.GetCustomerAsync(new Guid("11DA4696-CEA3-4A6D-8E83-013F1C479618")).Result;
            this.SaveCommand = new RelayCommand(SaveCommandExecuted, SaveCommandCanExecute);
        }

        public async void SaveCommandExecuted(object obj)
        {
            await this.CustomerRepository.UpdateCustomerAsync(Customer);
        }

        public bool SaveCommandCanExecute(object obj)
        {
            if (!String.IsNullOrEmpty(this.Customer.FirstName) && !String.IsNullOrEmpty(this.Customer.LastName) && !String.IsNullOrEmpty(this.Customer.Phone))
                return true;
            else
                return false;
        }
    }
}
